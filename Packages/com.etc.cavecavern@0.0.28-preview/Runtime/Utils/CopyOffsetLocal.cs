using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyOffsetLocal : MonoBehaviour
{
    [SerializeField] private Transform parent;
    public Vector3 initialVal;
    // Copies the transform of the parent object as an offset to self
    // Start is called before the first frame update
    void Start()
    {
        initialVal = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Apply offset from start to current position
        transform.localPosition = parent.localPosition + initialVal;
    }
}
