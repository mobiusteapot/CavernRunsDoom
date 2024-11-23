using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour {
	[Header("Input")]
	[SerializeField] private InputActionReference startGameAction = null;
	private bool isInSelectMap = false;
	private bool isInSelectDifficulty = false;
	[Space]
	[SerializeField] private WadLoader wadLoader = null;
	[Header("New Game")]
	[SerializeField] private GameObject startPanel = null;
	[SerializeField] private GameObject mapSelectPanel = null;
	[SerializeField] private GameObject difficultyPanel = null;

	[Header("Game Parts")]
	[SerializeField] private MusicManager musicManager = null;
	[SerializeField] private GameObject endCard = null;

	private static MenuManager Instance;

		private void OnEnable() {
		startGameAction.action.Enable();
		startGameAction.action.performed += OnStartGame;
	}
	private void OnDisable()
	{
		startGameAction.action.performed -= OnStartGame;
	}

	private void OnStartGame(InputAction.CallbackContext context){
		if(!isInSelectMap){
			NewGame();
			isInSelectMap = true;
		}
		else if(!isInSelectDifficulty){
			SelectEpisode(1);
			isInSelectDifficulty = true;
		}
		else{
			SelectDifficulty();
		}
	}

	void Start() {
		MenuManager.Instance = this;
	}

	void Update () {
		if (Doom.isLoaded && Input.GetKeyDown (KeyCode.Escape)) {
			Doom.isPaused = !Doom.isPaused;
			Time.timeScale = Doom.isPaused ? 0 : 1;
			startPanel.SetActive(Doom.isPaused);
		}
	}

	public static void EnableEndCard () {
		Instance.endCard.SetActive(true);
	}

	public void PauseGame() {
		Reset();
		Time.timeScale = 0;
	}

	public void Reset () {
		startPanel.SetActive(true);
		mapSelectPanel.SetActive(false);
		difficultyPanel.SetActive(false);
	}

	public void NewGame () {
		startPanel.SetActive(false);
		mapSelectPanel.SetActive(true);
		difficultyPanel.SetActive(false);
	}

	public void SelectEpisode(int episode) {
		wadLoader.SetAutoLoadEpisode(episode);
		mapSelectPanel.SetActive(false);
		difficultyPanel.SetActive(true);
	}

	// TODO: give this some actual effort
	public void SelectDifficulty() {
		Doom.isPaused = false;
        Time.timeScale = 1;
		wadLoader.LoadMapSafe();
		difficultyPanel.SetActive(false);
		//PlayEpisodeFirstMusic();
		Doom.player.SetInputEnabled(true);
	}
}
