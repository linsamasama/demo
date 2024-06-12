using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public float attackRange = 5f; // 攻击范围  
    public LayerMask attackLayerMask; // 用于过滤哪些层可以被攻击  
    public void Attack()
    {
        // 获取角色朝向的射线起点（这里以角色的位置为例）  
        Vector3 rayOrigin = transform.position;
        // 设置射线的终点为角色前方attackRange距离的位置  
        Vector3 rayDirection = transform.forward;
        Ray ray = new Ray(rayOrigin, rayDirection);


        // 尝试进行射线投射  
        if (Physics.Raycast(ray, out RaycastHit hit, attackRange, attackLayerMask))
        {
            // 如果射线击中了某个物体  
            Debug.Log("Hit something: " + hit.transform.name);
            
        }
        else
        {
            // 没有击中任何物体  
            Debug.Log("No hit");
        }
    }
}
