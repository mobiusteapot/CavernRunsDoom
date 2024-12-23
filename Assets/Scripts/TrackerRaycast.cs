using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    public float maxDistance = 10f;
    public float horizontalAngle;
    public float verticalAngle;
    public bool isTracking;

    
    void Update()
    {
        // Shoot raycast from forward direction of self, until it hits something in the target layer
        // Check if is a mesh collider, then set horizontal angle to RaycastHit.textureCoord.x
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance, targetLayer))
        {
            if (hit.collider is MeshCollider)
            {
                isTracking = true;
                horizontalAngle = hit.textureCoord.x;
                verticalAngle = hit.textureCoord.y;
            }
        }   
        else
        {
            isTracking = false;
        }
    }
}
