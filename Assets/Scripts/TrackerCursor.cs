using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class TrackerCursor : MonoBehaviour
{
    // Gets horizontal and vertical angles from the TrackerRaycast
    [SerializeField] private TrackerRaycast trackerRaycast;
    // Aligns self on UI canvas based on horizontal and vertical angles
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private RawImage rawImage;
    private bool hasImage;
    private void Start()
    {
        hasImage = rawImage != null;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasImage)
        {
            rawImage.enabled = trackerRaycast.isTracking;
        }
        if (trackerRaycast.isTracking)
        {
            // Set position of self based on horizontal and vertical angles
            rectTransform.anchorMin = new Vector2(trackerRaycast.horizontalAngle, trackerRaycast.verticalAngle);
            rectTransform.anchorMax = new Vector2(trackerRaycast.horizontalAngle, trackerRaycast.verticalAngle);
        }
    }
}
