using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockCreator : MonoBehaviour
{
    public GameObject prefabToSpawn; // 预制体  
    public Transform spawnPoint; //位置
     bool isBlock=true;
    void Start()
    {
   
    }

    void Update()
    {
        Debug.Log(isBlock);
        if (Input.GetMouseButtonDown(1)&&isBlock==true) // 鼠标右键点击  
        {
            Instantiate(prefabToSpawn,spawnPoint.position,Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("方块"))
        {
            isBlock = false;
            Debug.Log("进入"); 
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("方块"))
        {
            isBlock = true;
            Debug.Log("出去");
        }
    }

}

