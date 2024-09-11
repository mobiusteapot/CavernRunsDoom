using UnityEngine;
namespace ETC.CaveCavern
{
    [CreateAssetMenu(fileName = "CavernRenderSettings", menuName = "Cavern/CavernRenderSettings")]
    public class CavernRenderSettings : ScriptableObject
    {

        [Header("IPD in meters")]
        public float stereoSeparation = 0.064f;
        #region SingleCameraRenderSettings
        [Header("Render Settings")]
        [SerializeField] private CubemapRenderMask cubemapRenderMask;
        [SerializeField] private CubemapResolution perEyeRes;
        #endregion
        // Todo: Use this for multi cam rig
        [field: SerializeField] public int OutputWidth { get; private set; }
        [field: SerializeField] public int OutputHeight { get; private set; }
        #region Graphics Settings
        // Todo: This is unused
        public RenderTextureFormat RenderTextureFormat = RenderTextureFormat.ARGB32;
        public FilterMode FilterMode = FilterMode.Bilinear;
        // Anti-aliasing as an enum
        public enum AntiAliasingEnum
        {
            None = 1,
            _2x = 2,
            _4x = 4,
            _8x = 8
        }
        [SerializeField]
        private AntiAliasingEnum _antiAliasing = AntiAliasingEnum._2x;
        public int AntiAliasing { get { return (int)_antiAliasing; } set { _antiAliasing = (AntiAliasingEnum)value; } }


        #endregion

        private void Reset()
        {
            cubemapRenderMask = (CubemapRenderMask)63;
            perEyeRes = CubemapResolution.Medium;
            OutputWidth = 3840;
            OutputHeight = 720;
        }

        public int GetPerEyeRes()
        {
            return (int)perEyeRes;
        }
        public int GetCubemapMask()
        {
            return (int)cubemapRenderMask;
        }
    }
}
