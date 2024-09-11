using System.Collections;
using System.Collections.Generic;
using ETC.CaveCavern;
using UnityEngine;
using UnityEngine.UI;
// Render the UI at half the native height, to a render texture
[RequireComponent(typeof(Camera))]
public class UICamera : MonoBehaviour
{
    private Camera cam;
    public RenderCam renderCam;
    public RenderTexture RT;
    public RawImage TopImage;
    public RawImage BottomImage;
    void Start()
    {
        cam = GetComponent<Camera>();
        RT = new RenderTexture(Screen.width, Screen.height / 2, 24);
        RT.format = RenderTextureFormat.ARGB32;
        cam.targetTexture = RT;

        // Set top and bottom images to the render texture
        TopImage.texture = RT;
        BottomImage.texture = RT;
    }

    private void LateUpdate()
    {
        // Todo: This automatically
        // Blit the UI to rendercam's texture
        //CaveCamera.BlitToOutFrame(RT);
    }
}
