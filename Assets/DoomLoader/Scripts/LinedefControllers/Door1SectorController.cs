using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1SectorController : MonoBehaviour
{
    public float speed = 2;

    public float originalHeight;
    public float targetHeight;
    public float currentHeight;

    public enum State
    {
        Closed,
        Open,
        Opening,
        Closing
    }

    public State CurrentState = State.Closed;

    public float waitTime;

    void Update()
    {
        switch (CurrentState)
        {
            default:
            case State.Closed:
                break;

            case State.Opening:
                currentHeight += Time.deltaTime * speed;
                if (currentHeight > targetHeight)
                {
                    currentHeight = targetHeight;
                    CurrentState = State.Open;
                }
                transform.position = new Vector3(transform.position.x, currentHeight - originalHeight, transform.position.z);
                break;

            case State.Open:
                waitTime -= Time.deltaTime;
                if (waitTime <= 0)
                    CurrentState = State.Closing;
                break;

            case State.Closing:
                currentHeight -= Time.deltaTime * speed;
                if (currentHeight < originalHeight)
                {
                    currentHeight = originalHeight;
                    CurrentState = State.Closed;
                }
                transform.position = new Vector3(transform.position.x, currentHeight - originalHeight, transform.position.z);
                break;
        }
    }
}