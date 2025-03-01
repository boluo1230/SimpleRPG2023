using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavalinWeapon : Weapon
{
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public GameObject bulletGo;


    private void Start()
    {
        SpawnBullet();
    }

    public override void Attack()
    {

        //Debug.Log("Player forward: " + transform.forward);
        //Debug.Log("Player position: " + transform.position);

        //GameObject bulletGo = GameObject.Instantiate(
        //    bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);

        //bulletGo.transform.rotation =
        //    Quaternion.LookRotation(transform.forward, -transform.up);
        //bulletGo.transform.Rotate(90, 0, 0, Space.Self);

        //Rigidbody rb = bulletGo.GetComponent<Rigidbody>();
        //rb.velocity = transform.forward * bulletSpeed;
        //rb.useGravity = false;

        //Destroy(bulletGo, 5f);



        if (bulletGo != null)
        {
            // 发生攻击前开启 Capsule Collider
            bulletGo.GetComponent<Collider>().enabled = true;
            bulletGo.transform.parent = null;
            //transform.forward 是当前对象的局部 Z 轴正方向（即“前进方向”），在世界坐标系中具体方向由对象的旋转决定。
            //transform.forward * bulletSpeed 让铲子以指定速度沿当前对象的“前进方向”发射。
            bulletGo.GetComponent<Rigidbody>().velocity =
                transform.forward * bulletSpeed;


            Destroy(bulletGo, 1f);
            bulletGo = null;

            //0.5s后调用
            Invoke("SpawnBullet", 0.1f);
        }
        else
        {
            return;
        }

    }

    private void SpawnBullet()
    {

        Debug.Log("SpawnBullet begin: ");

        // 实例化一个铲子对象（GameObject）
        // 使用 GameObject.Instantiate 方法生成预制体 bulletPrefab 的实例
        // 位置设置为当前玩家对象的 transform.position（位置）
        // 旋转设置为当前玩家对象的 transform.rotation（旋转）
        bulletGo = GameObject.Instantiate(
            bulletPrefab,
            transform.position - transform.right * 0.9f + transform.forward * 0.7f,
            transform.rotation);

        //设置展示
        bulletGo.SetActive(true);

        // 禁用 Capsule Collider
        // 防止手中的武器碰撞到其他物体后，触发 OnCollisionEnter 
        bulletGo.GetComponent<Collider>().enabled = false;

        Debug.Log("SpawnBullet bulletGo name: " + bulletGo.name);

        bulletGo.transform.SetParent(transform);

        Debug.Log("SpawnBullet bulletGo set parent: " + transform.position);
    }

}
