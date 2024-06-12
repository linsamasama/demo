using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaBaiChu_z : MonoBehaviour
{
    public float rotateSpeed = 50f; // 旋转速度  
    public float maxAngle = 90f; // 最大旋转角度（在X轴上）  
    private bool rotatingForward = true; // 旋转方向标志  
    private float currentAngle = 0f; // 当前旋转角度  

    void Start()
    {
        StartCoroutine(RotateBackAndForthXCoroutine());
    }

    IEnumerator RotateBackAndForthXCoroutine()
    {
        while (true) // 无限循环  
        {
            if (rotatingForward)
            {
                // 向前旋转  
                while (currentAngle < maxAngle)
                {
                    currentAngle += rotateSpeed * Time.deltaTime; // 更新当前角度  
                    transform.localRotation = Quaternion.Euler(0, 0, currentAngle); // 设置旋转  
                    yield return null; // 等待一帧  
                }
                rotatingForward = false; // 更改旋转方向  
            }
            else
            {
                // 向后旋转  
                while (currentAngle > -maxAngle)
                {
                    currentAngle -= rotateSpeed * Time.deltaTime; // 更新当前角度  
                    transform.localRotation = Quaternion.Euler(0, 0, currentAngle); // 设置旋转  
                    yield return null; // 等待一帧  
                }
                rotatingForward = true; // 更改回原始旋转方向  
            }
        }
    }
}
