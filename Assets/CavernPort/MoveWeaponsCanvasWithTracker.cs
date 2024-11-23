using UnityEngine;

// Adjust the position of the weapons canvas based on the tracker's rotation
[RequireComponent(typeof(RectTransform))]
public class MoveWeaponsCanvasWithTracker : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TrackerRaycast trackerRaycast;
    [SerializeField] private float lerpMultiplier = 0.1f;
    private Vector2 initialAnchorMin;
    private void Reset()
    {
        TryGetComponent(out rectTransform);
    }
    private void Start()
    {
        initialAnchorMin = rectTransform.anchorMin;
    }
   private void Update()
    {
        // Use only the horizontal angle to lerp towards the most recent horizontal angle, ignore vertical angle
        if(trackerRaycast.isTracking)
        {
            rectTransform.anchorMin = Vector2.Lerp(rectTransform.anchorMin, new Vector2(trackerRaycast.horizontalAngle, initialAnchorMin.y), lerpMultiplier);
            rectTransform.anchorMax = Vector2.Lerp(rectTransform.anchorMax, new Vector2(trackerRaycast.horizontalAngle, initialAnchorMin.y), lerpMultiplier);
        }
    }
}
