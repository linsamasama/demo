using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    //移动
    public float speed = 2f; 
    private Vector3 movement; 

    //旋转
    public float mouseSensitivity = 100f;
    private float xAxis = 0f;
    private float yAxis = 0f;


    public Rigidbody rb; // 假设你的角色有一个Rigidbody组件  
    public float jumpForce = 500f; // 跳跃的力度  
   
    void Start()
    {
        // 确保Rigidbody组件已经附加到当前GameObject上  
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //移动
        float horizontal = Input.GetAxis("Horizontal");  
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0f, vertical);
        movement = movement * speed * Time.deltaTime;
        transform.Translate(movement);
        //旋转
        if (Input.GetMouseButton(0))  
        {
            xAxis += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            yAxis -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            //限制
            yAxis = Mathf.Clamp(yAxis, -90f, 90f);
            transform.rotation = Quaternion.Euler(yAxis, xAxis, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Jump();
        }

    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  
    }
}