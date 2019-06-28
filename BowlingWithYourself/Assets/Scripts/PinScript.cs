using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    private BallController ball;
    private bool knockedOver = false;
    public float MinAngle = 0.3f;

    private void Awake()
    {
        if (ball == null)
        {
            GameObject.FindGameObjectWithTag("Ball");
        }
    }

    private void Update()
    {
        if (ball != null)
        {
            if ((Vector3.Dot(gameObject.transform.up, Vector3.up) < MinAngle && Vector3.Dot(gameObject.transform.up, Vector3.up) > -MinAngle) && !knockedOver)
            {
                ball.ChangeScore(1);
                knockedOver = true;
            }
        }
    }
}
