using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public enum EnemyState
    {
        NormalState,
        FightingState,
        MovingState,
        RestingState
    }

    private EnemyState state = EnemyState.NormalState;
    private EnemyState childState = EnemyState.RestingState;
    private NavMeshAgent enemyAgent;

    public float restTime = 2;
    private float restTimer = 0;

    public int HP = 100;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.NormalState)
        {
            if (childState == EnemyState.RestingState)
            {
                //在 Unity 游戏引擎中，Time.deltaTime 是一个非常重要的属性，表示 上一帧到当前帧的时间间隔（以秒为单位）。
                //它的核心作用是确保游戏逻辑的帧率无关性（Frame-Rate Independent），即无论设备性能如何（帧率高低），游戏中的运动、动画或计时都能保持平滑一致。
                //--在 60 FPS 时，Time.deltaTime ≈ 0.0167 秒。
                //--在 30 FPS 时，Time.deltaTime ≈ 0.0333 秒。
                //在 Update() 中处理运动、动画或计时时，始终将其与速度值相乘。
                //避免直接使用固定数值，以确保不同设备上的表现一致。
                restTimer += Time.deltaTime;

                if (restTimer > restTime)
                {
                    Vector3 randomPosition = FindRandomPosition();
                    enemyAgent.SetDestination(randomPosition);
                    childState = EnemyState.MovingState;
                }
            }
            else if (childState == EnemyState.MovingState)
            {
                if (enemyAgent.remainingDistance <= 0)
                {
                    restTimer = 0;
                    childState = EnemyState.RestingState;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(30);
        }

    }

    Vector3 FindRandomPosition()
    {
        Vector3 randomDir = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        return transform.position + randomDir.normalized * Random.Range(2, 5);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            GetComponent<Collider>().enabled = false;
            int count = Random.Range(0, 4);
            for (int i = 0; i < count; i++)
            {
                ItemSO item = ItemDBManager.Instance.GetRandomItem();

                //原地爆装备
                //Quaternion.identity 表示“无旋转”（即朝向与世界坐标系对齐）
                GameObject go = GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
                

                //禁用掉动画，不然生成的位置会被动画受影响
                Animator anim = go.GetComponent<Animator>();
                if (anim != null)
                {
                    anim.enabled = false;
                }

            }
            Destroy(this.gameObject);
        }
    }

}
