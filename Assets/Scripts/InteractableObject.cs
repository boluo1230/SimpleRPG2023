using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{

    private NavMeshAgent playerAgent;
    private bool hasInteracted = false;

    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        //设置 player 与碰撞体的距离
        playerAgent.stoppingDistance = 2;
        playerAgent.SetDestination(transform.position);

        hasInteracted = false;
    }

    void Update()
    {
        //playerAgent.pathPending 用于检查 NavMeshAgent 是否正在计算路径。
        //在路径计算完成之前，可以暂停某些操作（如移动或动画），以避免不必要的错误或性能问题。
        if (playerAgent != null && hasInteracted == false && playerAgent.pathPending)
        {
            Debug.Log("Interact process, pathPending:" + playerAgent.pathPending);
            Debug.Log("Interact process, remainingDistance:" + playerAgent.remainingDistance);
            if (playerAgent.remainingDistance <= 2)
            {
                Interact();
                //保证 Interact 在一次点击后只调用一次
                hasInteracted = true;
            }
        }

        if (playerAgent != null && !playerAgent.pathPending)
        {
            hasInteracted = true;
        }

    }


    protected virtual void Interact()
    {
        Debug.Log("Interact process");
    }
}
