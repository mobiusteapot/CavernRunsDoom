using UnityEngine;

namespace ETC.CaveCavern
{
    /// <summary>
    /// Renders the UI at both heights for Top/Bottom UI support
    /// </summary>
    public class UIBlitter : MonoBehaviour
    {
        // Todo: URP
        public UICamera uiCamera;
        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            // Create a temporary render texture to hold the final output
            RenderTexture temp = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);

            // Copy the camera's source texture to the temporary render texture
            Graphics.Blit(source, temp);

            // Set the render target to the temporary texture
            Graphics.SetRenderTarget(temp);
            GL.PushMatrix();
            GL.LoadOrtho(); // Load orthographic projection for full-screen quad

            // Draw the top half
            DrawTexture(uiCamera.RT, 0, 0.5f, 1, 0.5f);

            // Draw the bottom half
            DrawTexture(uiCamera.RT, 0, 0, 1, 0.5f);

            GL.PopMatrix();

            // Finally, copy the modified temp texture to the destination
            Graphics.Blit(temp, destination);
            RenderTexture.ReleaseTemporary(temp);
        }

        private void DrawTexture(RenderTexture texture, float x, float y, float width, float height)
        {
            // Set the material for the texture
            if (texture != null)
            {
                Graphics.DrawTexture(new Rect(x, y + height, width, -height), texture);
            }
        }
    }

}