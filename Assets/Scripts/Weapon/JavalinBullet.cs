using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavalinBullet : MonoBehaviour
{

    private Rigidbody rgd;
    private Collider col;
    public int attackValue;

    private void Start()
    {
        Debug.Log("Rigidbody Start: " + gameObject.name);
        rgd = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rgd != null) // 检查 Rigidbody 是否存在
        {
            Debug.Log("我自己是: " + gameObject.name + ", 撞到的是: " + collision.gameObject.name);
            //rgd.velocity = Vector3.zero;
            rgd.isKinematic = true; // 停止物理模拟
        }
        else
        {
            Debug.LogWarning("Rigidbody is null, skipping disable: " + gameObject.name);
        }

        if (col != null) // 检查 Collider 是否存在
        {
            col.enabled = false; // 第 19 行
        }
        else
        {
            Debug.LogWarning("Collider is null, skipping disable: " + gameObject.name);
        }

        if (collision.gameObject.tag == Tag.ENEMY)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(attackValue);
        }

        Destroy(this.gameObject, 0.5f);
    }
}
