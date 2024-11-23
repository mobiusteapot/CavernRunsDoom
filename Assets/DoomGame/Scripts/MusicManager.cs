using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	[Header("TEMPORARY SOLUTION")]
	[SerializeField] private AudioClip D_INTROA = null;
	[SerializeField] private AudioClip D_INTER = null;
	[SerializeField] private AudioClip D_E1M1 = null;
	[SerializeField] private AudioSource audioSource;

	[SerializeField]
	private List<MusicContainer> musicContainers = new List<MusicContainer>();
	private bool isInitalized = false;
	void Start () {
		StartCoroutine(PlayMusic("D_INTROA", 0.15f));
	}
	private void OnEnable(){
		if (!isInitalized) return;
		// Subscribe after first scene loaded
		MapLoader.Instance.OnLevelChanged += ctx => ChangeMusic(ctx);
	}
	private void OnDisable(){
		MapLoader.Instance.OnLevelChanged -= ctx => ChangeMusic(ctx);
	}
	public void ChangeMusic(string newMapName){
		foreach(var mc in musicContainers){
			if(mc.LevelName == newMapName){
				Debug.Log("Changing audio clip to:" + newMapName);
				audioSource.clip = mc.Music;
				audioSource.volume = mc.Volume;
				audioSource.Play();
				return;
			}
		}

		Debug.Log("Did not find track with ID: " + newMapName);
	}
	public void PlayMusic(string musicID) {
		//StartCoroutine(PlayMusic(musicID, 0));
	}

	private IEnumerator PlayMusic (string musicID, float wait) {
		yield return new WaitForSeconds(wait); // we need a small wait for the SoundLoader to initialise first time
		if(!isInitalized){
			isInitalized = true;
			OnEnable();
		}
		//audioSource.PlayOneShot(SoundLoader.LoadSound(musicID));

		Debug.LogWarning("TODO: Fix Format Issue. Defaulting to temporary solution...");
		switch (musicID) {
		case "D_INTROA":
			audioSource.clip = D_INTROA;
			audioSource.Play();
			break;
		case "D_INTER":
			audioSource.clip = D_INTER;
			audioSource.Play();
			break;
		case "D_E1M1":
			audioSource.clip = D_E1M1;
			audioSource.Play();
			break;
		}
	}
}
