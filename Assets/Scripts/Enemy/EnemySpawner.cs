using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//���Ƶ����Զ�����
public class EnemySpawner : MonoBehaviour
{

    public float spanwerTime;
    public GameObject enemyPrefab;
    public float spanwerTimer = 0;
    public int maxEnemyCount;

    // Update is called once per frame
    void Update()
    {

        // ��ȡ���б�ǩΪ "Enemy" �� GameObject
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null && enemies.Length >= maxEnemyCount)
        {
            //��֤�������ֻ��10��
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
