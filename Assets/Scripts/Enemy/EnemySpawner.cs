using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//控制敌人自动生成
public class EnemySpawner : MonoBehaviour
{

    public float spanwerTime;
    public GameObject enemyPrefab;
    public float spanwerTimer = 0;
    public int maxEnemyCount;

    // Update is called once per frame
    void Update()
    {

        // 获取所有标签为 "Enemy" 的 GameObject
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null && enemies.Length >= maxEnemyCount)
        {
            //保证敌人最多只有10个
            return;
        }

        spanwerTimer += Time.deltaTime;
        if (spanwerTimer > spanwerTime)
        {
            GameObject enemyGameObj = GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyGameObj.tag = Tag.ENEMY;
            spanwerTimer = 0;
        }


    }
}
