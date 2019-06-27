using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public Rigidbody RB;
    public GameObject BallCamera;
    public Text PinScoretxt;

    private float power = 0;
    private float rotation = 0.0f;
    private Vector3 offset;
    private int pinsHit = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        offset = new Vector3(gameObject.transform.position.x - 3, gameObject.transform.position.y, gameObject.transform.position.z - 3);
        ChangeScore(0);
    }

    void Update()
    {
        BallCamera.transform.position = gameObject.transform.position + offset;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            power += -Input.GetAxis("Mouse Y");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            RB.AddForce(BallCamera.transform.forward * power, ForceMode.Impulse);
            power = 0;
        }
        else
        {
            BallCamera.transform.RotateAround(gameObject.transform.position, Vector3.up, -Input.GetAxis("Mouse X"));
            BallCamera.transform.RotateAround(gameObject.transform.position, Vector3.forward, Input.GetAxis("Mouse Y"));

            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), -Vector3.up) * offset;
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), -Vector3.forward) * offset;

            BallCamera.transform.LookAt(gameObject.transform);
        }

    }

    public void ChangeScore(int value)
    {
        pinsHit += value;
        PinScoretxt.text = "Pins Hit: " + pinsHit.ToString();
    }
}