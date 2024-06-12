using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnMouseClick : MonoBehaviour
{
    public GameObject prefabToInstantiate;

    // 更新函数，用于检测鼠标输入  
    void Update()
    {
        // 检查鼠标左键是否被按下  
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击的屏幕坐标  
            Vector3 mousePosition = Input.mousePosition;

            // 将屏幕坐标转换为世界坐标（通常是在摄像机的前方）  
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            // 尝试投射射线并检查是否击中了某个物体  
            if (Physics.Raycast(ray, out hit))
            {
                // 如果击中了物体，可以在该位置实例化预制体  
                // 这里我们假设你想要在击中的位置实例化物体  
                Instantiate(prefabToInstantiate, hit.point, Quaternion.identity);
            }
            else
            {
                // 如果没有击中任何物体，可以在摄像机前方的一个固定距离处实例化预制体  
                // 例如，在摄像机前方5米处  
                Vector3 worldPosition = Camera.main.transform.position + (Camera.main.transform.forward * 5f);
                Instantiate(prefabToInstantiate, worldPosition, Quaternion.identity);
            }
        }
    }
}
