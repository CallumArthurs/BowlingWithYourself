using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float power = 0;
    public Rigidbody RB;
    public GameObject BallCamera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            power += -Input.GetAxis("Mouse Y");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            RB.AddForce(gameObject.transform.forward * power, ForceMode.Impulse);
            power = 0;
        }

        BallCamera.transform.position = transform.position - new Vector3(0,-1,1.8f);
    }
}
