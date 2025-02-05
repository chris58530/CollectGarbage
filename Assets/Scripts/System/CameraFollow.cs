using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target; // 要跟隨的目標（設為玩家）
    public Vector3 offset = new Vector3(0f, 10f, -10f); // 攝影機與玩家的偏移
    public float followSpeed = 5f; // 跟隨速度

    void LateUpdate()
    {
        // 計算目標位置
        Vector3 targetPosition = target.position + offset;

        // 平滑移動攝影機
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // 確保攝影機始終看著目標
        transform.LookAt(target);
    }
}
