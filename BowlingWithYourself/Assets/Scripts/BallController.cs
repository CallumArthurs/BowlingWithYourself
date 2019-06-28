using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public Rigidbody RB;
    public GameObject BallCamera;
    public Text PinScoretxt;
    public Image PowerBar;
    public Slider slider;
    public float Mousesensitivity;
    public float powerLimit = 0;
    public Gradient Gradient;
    public float minSpeed = 3.0f;
    public float DistFromBall;

    public float PowerMultipiler = 1;
    private float power = 0;
    //private Vector3 offset;

    private Vector3 Xoffset;
    private Vector3 Yoffset;
    private float rotation;
    private Vector3 PrevPos;

    private int pinsHit = 0;
    private bool HitBall;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        Xoffset = new Vector3(BallCamera.transform.position.x - gameObject.transform.position.x, 0, BallCamera.transform.position.z - gameObject.transform.position.z);
        Yoffset = new Vector3(0, BallCamera.transform.position.y - gameObject.transform.position.y, 0);
        //offset = BallCamera.gameObject.transform.position - gameObject.transform.position;
        PowerBar.color = Color.green;
        slider.value = 0;
        ChangeScore(0);
        rotation = BallCamera.transform.localRotation.y;
        PrevPos = new Vector3(0, 0, 0);
    }

    void Update()
    {

        if (transform.position.y < 0.0f)
        {
            transform.position = PrevPos;
            RB.velocity = new Vector3(0, 0, 0);
            HitBall = false;
        }

        if (RB.velocity.magnitude < minSpeed && HitBall)
        {
            RB.velocity = new Vector3(0, 0, 0);
            HitBall = false;
        }

        //BallCamera.transform.position = gameObject.transform.position + offset;
        //BallCamera.transform.position = gameObject.transform.position + (Xoffset + Yoffset);

        if (Input.GetKey(KeyCode.Mouse0) && RB.velocity.magnitude == 0.0f)
        {
            power += -Input.GetAxis("Mouse Y");

            Debug.Log(1 * (power % powerLimit) / powerLimit);

            if (power > powerLimit)
            {
                PowerBar.color = Gradient.Evaluate(1);
                slider.value = 1;
            }
            else
            {
                PowerBar.color = Gradient.Evaluate(1 * (power % powerLimit) / powerLimit);
                slider.value = 1 * ((power % powerLimit) / powerLimit);
            }

            HitBall = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && RB.velocity.magnitude == 0.0f)
        {
            if (power > powerLimit)
            {
                power = powerLimit;
            }

            PrevPos = transform.position;

            PowerBar.color = Color.green;
            slider.value = 0;
            RB.AddForce(BallCamera.transform.forward * (power * PowerMultipiler), ForceMode.Impulse);
            power = 0;
        }
        else if (Time.timeScale != 0)
        {

            BallCamera.transform.Rotate(Vector3.right,Input.GetAxis("Mouse Y"));
            BallCamera.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
            BallCamera.transform.position = gameObject.transform.position - BallCamera.transform.forward * DistFromBall;
            ///BallCamera.transform.RotateAround(gameObject.transform.position, Vector3.up, Input.GetAxis("Mouse X"));
            //BallCamera.transform.RotateAround(gameObject.transform.position, Vector3.right, Input.GetAxis("Mouse Y"));

            //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), -Vector3.up) * offset;
            //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), -Vector3.forward) * offset;

            ///Xoffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * Mousesensitivity, Vector3.up) * Xoffset;
            //Yoffset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), Vector3.right) * Yoffset;

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

    private void OnTriggerEnter(Collider other)
    {
        LevelScores.Scores[LevelSelect.levelNum] = pinsHit;
        LevelSelect.LoadScene0();
    }
}