using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackerEmulatorSupport : MonoBehaviour
{
    // If SteamVR not detecte, disable CopyOffsetLocal and CopyTransformRotation
    [SerializeField] private CopyOffsetLocal copyOffsetLocal;
    [SerializeField] private CopyTransformRotation copyTransformRotation;

    private void Reset()
    {
        TryGetComponent(out copyOffsetLocal);
        TryGetComponent(out copyTransformRotation);
    }

    private void Start(){
        // Disable CopyOffsetLocal and CopyTransformRotation if SteamVR not detected
        if(SteamVR.instance == null){
            copyOffsetLocal.enabled = false;
            copyTransformRotation.enabled = false;
        }
    }
}
