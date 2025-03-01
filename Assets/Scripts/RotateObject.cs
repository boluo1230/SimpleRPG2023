using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speed = 50f; // 旋转速度，单位：度/秒

    void Update()
    {
        // 每帧绕 Y 轴旋转一点
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
