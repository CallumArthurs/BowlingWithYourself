using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    private BallController ball;
    private bool knockedOver = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ball = collision.gameObject.GetComponent<BallController>();
        }
    }

    private void Update()
    {
        if (ball != null)
        {
            if (Vector3.Dot(gameObject.transform.up, Vector3.up) < 0.3f && Vector3.Dot(gameObject.transform.up, Vector3.up) > -0.3f && !knockedOver)
            {
                ball.ChangeScore(1);
                knockedOver = true;
            }
        }
    }
}
