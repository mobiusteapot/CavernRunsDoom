using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforceRotation : MonoBehaviour
{
    [Tooltip("Which object's rotation do we copy?")]
    public Transform Example;

    [Tooltip("Do we copy the x axis?")]
    public bool CopyX;

    [Tooltip("Do we copy the y axis?")]
    public bool CopyY;

    [Tooltip("Do we copy the z axis?")]
    public bool CopyZ;

    [Space]

    [Tooltip("Apply rotation locally?")]
    public bool Local;

    [Tooltip("Do we apply the inverse of the copied rotation?")]
    public bool Inverse;

    [Space]
    public Vector3 Offset;
    public bool OffsetX;
    public bool OffsetY;
    public bool OffsetZ;

    // Update is called once per frame
    void Update()
    {
        if (Example == null)
            transform.rotation = Quaternion.identity;
        else
        {
            var newRot = Quaternion.Euler(
                CopyX ? Example.rotation.eulerAngles.x : 0,
                CopyY ? Example.rotation.eulerAngles.y : 0,
                CopyZ ? Example.rotation.eulerAngles.z : 0);
            // Apply as is, or invert it
            if (Local)
                transform.localRotation = Inverse ? Quaternion.Inverse(newRot) : newRot;
            else
                transform.rotation = Inverse ? Quaternion.Inverse(newRot) : newRot;
        }

        // Offset rotation by degrees as defined by "Offset"
        if (OffsetX || OffsetY || OffsetZ)
        {
            var offsetRot = Quaternion.Euler(
                OffsetX ? Offset.x : 0,
                OffsetY ? Offset.y : 0,
                OffsetZ ? Offset.z : 0);
            transform.rotation *= offsetRot;
        }
    }
}
