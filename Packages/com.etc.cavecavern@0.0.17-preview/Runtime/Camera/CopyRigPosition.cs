using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// For setting position outside of cavern rig, and then copying it on update
public class CopyRigPosition : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        transform.position = Target.position;
    }
}
