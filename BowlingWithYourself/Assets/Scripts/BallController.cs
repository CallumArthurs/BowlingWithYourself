using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public Rigidbody RB;
    public GameObject BallCamera;
    public Text PinScoretxt;
    public float Mousesensitivity;

    private float power = 0;
    //private Vector3 offset;

    private Vector3 Xoffset;
    private Vector3 Yoffset;

    private int pinsHit = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        Xoffset = new Vector3(BallCamera.transform.position.x - gameObject.transform.position.x, 0, BallCamera.transform.position.z - gameObject.transform.position.z);
        Yoffset = new Vector3(0, BallCamera.transform.position.y - gameObject.transform.position.y, 0);
        //offset = BallCamera.gameObject.transform.position - gameObject.transform.position;
        ChangeScore(0);
    }

    void Update()
    {
        //BallCamera.transform.position = gameObject.transform.position + offset;
        BallCamera.transform.position = gameObject.transform.position + Xoffset + Yoffset;

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

            BallCamera.transform.RotateAround(gameObject.transform.position, Vector3.up, Input.GetAxis("Mouse X"));
            //BallCamera.transform.RotateAround(gameObject.transform.position, gameObject.transform.right, Input.GetAxis("Mouse Y"));

            //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), -Vector3.up) * offset;
            //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), -Vector3.forward) * offset;

            Xoffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * Mousesensitivity, Vector3.up) * Xoffset;
            Yoffset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), Vector3.right) * Yoffset;

            BallCamera.transform.LookAt(gameObject.transform);
        }

    }

    public void ChangeScore(int value)
    {
        pinsHit += value;
        RefreshUI();
    }

    private void RefreshUI()
    {
        PinScoretxt.text = "Pins Hit: " + pinsHit.ToString();
    }

    public void CursorLock(bool Value)
    {
        if (Value)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}