using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    private Rigidbody rb;

    protected Joystick joystick;
    protected Rockermovement joybutton;
    protected bool canJump;
    public float speed = 10f;

    public float mouseSensitivity = 100f;
   
    private float xRotation = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Rockermovement>();
    }


    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        // 获取鼠标的X和Y轴输入  
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    }
}


