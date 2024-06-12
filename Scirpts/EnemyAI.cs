using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform targetTransform; 
    public float detectionRadius = 5f; // 半径  
    public float approachSpeed = 3f; // 速度  
    public float stopDistance = 3f; // 距离

    private void Update()
    {
        // 计算敌人与角色之间的距离  
        float distance = Vector3.Distance(transform.position, targetTransform.position);
        if (distance <= detectionRadius && distance > stopDistance)
        {
            Vector3 direction = (targetTransform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f); 
            transform.position += direction * approachSpeed * Time.deltaTime;

            // 这里可以添加额外的逻辑，比如判断是否要攻击等  
        }
        // 如果距离小于停止距离，则停止移动或执行其他逻辑（比如攻击）  
    }
    public void SetTarget(Transform newTarget)
    {
        targetTransform = newTarget;
    }
}
