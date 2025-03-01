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
                //�� Unity ��Ϸ�����У�Time.deltaTime ��һ���ǳ���Ҫ�����ԣ���ʾ ��һ֡����ǰ֡��ʱ����������Ϊ��λ����
                //���ĺ���������ȷ����Ϸ�߼���֡���޹��ԣ�Frame-Rate Independent�����������豸������Σ�֡�ʸߵͣ�����Ϸ�е��˶����������ʱ���ܱ���ƽ��һ�¡�
                //--�� 60 FPS ʱ��Time.deltaTime �� 0.0167 �롣
                //--�� 30 FPS ʱ��Time.deltaTime �� 0.0333 �롣
                //�� Update() �д����˶����������ʱʱ��ʼ�ս������ٶ�ֵ��ˡ�
                //����ֱ��ʹ�ù̶���ֵ����ȷ����ͬ�豸�ϵı���һ�¡�
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

                //ԭ�ر�װ��
                //Quaternion.identity ��ʾ������ת��������������������ϵ���룩
                GameObject go = GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
                

                //���õ���������Ȼ���ɵ�λ�ûᱻ������Ӱ��
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
