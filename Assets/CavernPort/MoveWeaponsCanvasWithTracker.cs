using UnityEngine;

// Adjust the position of the weapons canvas based on the tracker's rotation
[RequireComponent(typeof(RectTransform))]
public class MoveWeaponsCanvasWithTracker : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Transform trackerTransform;
    [SerializeField] private float trackerRotationMin = 0;
    [SerializeField] private float trackerRotationMax = 270;
    [SerializeField] private float trackerDeadZone = 90;
    [SerializeField] private float rectTransformLeftMin = -1000;
    [SerializeField] private float rectTransformLeftMax = 1000;

    [SerializeField] private float lerpMultiplier = 0.1f;


    private float lastValidLeftPosition;

    private void Reset()
    {
        TryGetComponent(out rectTransform);
    }

   private void Update()
    {
        float trackerRotationY = trackerTransform.localEulerAngles.y;
        // Hack for quaternions being scary
        if (trackerRotationY > 180f)
        {
            trackerRotationY -= 360f;
        }

        // Check if tracker is within the dead zone, if in dead zone, skip moving
        if (trackerRotationY < trackerRotationMin - trackerDeadZone || trackerRotationY > trackerRotationMax + trackerDeadZone)
        {
            rectTransform.localPosition = new Vector3(lastValidLeftPosition, rectTransform.localPosition.y, rectTransform.localPosition.z);
            return;
        }

        trackerRotationY = Mathf.Clamp(trackerRotationY, trackerRotationMin, trackerRotationMax);

        float normalizedRotation = Mathf.InverseLerp(trackerRotationMin, trackerRotationMax, trackerRotationY);
        float targetLeftPosition = Mathf.Lerp(rectTransformLeftMin, rectTransformLeftMax, normalizedRotation);

        float newLeftPosition = Mathf.Lerp(rectTransform.localPosition.x, targetLeftPosition, lerpMultiplier);
        rectTransform.localPosition = new Vector3(newLeftPosition, rectTransform.localPosition.y, rectTransform.localPosition.z);

        lastValidLeftPosition = newLeftPosition;
    }
}
