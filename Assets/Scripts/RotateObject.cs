using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speed = 50f; // ��ת�ٶȣ���λ����/��

    void Update()
    {
        // ÿ֡�� Y ����תһ��
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
