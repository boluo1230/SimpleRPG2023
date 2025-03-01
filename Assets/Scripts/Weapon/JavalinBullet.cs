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
        if (rgd != null) // ��� Rigidbody �Ƿ����
        {
            Debug.Log("���Լ���: " + gameObject.name + ", ײ������: " + collision.gameObject.name);
            //rgd.velocity = Vector3.zero;
            rgd.isKinematic = true; // ֹͣ����ģ��
        }
        else
        {
            Debug.LogWarning("Rigidbody is null, skipping disable: " + gameObject.name);
        }

        if (col != null) // ��� Collider �Ƿ����
        {
            col.enabled = false; // �� 19 ��
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
