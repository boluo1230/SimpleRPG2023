using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

/**

1.NavMeshAgent：这是一个Unity组件，用于在导航网格（NavMesh）上移动物体。
它可以自动计算路径并让物体沿着路径移动。

2.Start函数：在游戏开始时调用，用于初始化playerAgent变量，
获取当前游戏对象上的NavMeshAgent组件。

3.Update函数：在每一帧调用，用于检测玩家的输入并更新游戏状态。
`当玩家按下鼠标左键时，代码会从主摄像机发射一条射线，射线的方向是从屏幕上的鼠标位置向场景中发射。
`如果射线碰撞到场景中的物体，Physics.Raycast会返回true，并且hit变量会存储碰撞点的信息。
`如果射线碰撞到物体，代码会将NavMeshAgent的目标位置设置为射线碰撞到的点，从而使玩家角色移动到该位置。

总结：
这段代码实现了一个简单的点击移动功能。
玩家点击屏幕上的某个位置，角色会自动移动到该位置。这是通过NavMeshAgent组件和射线检测来实现的。

 **/
public class NewBehaviourScript : MonoBehaviour
{
    // 声明一个私有的NavMeshAgent变量，用于控制玩家的导航
    private NavMeshAgent playerAgent;

    // Start is called before the first frame update
    // Start函数在游戏开始时调用，只调用一次
    void Start()
    {
        // 获取当前游戏对象上的NavMeshAgent组件，并将其赋值给playerAgent
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    // Update函数在每一帧调用
    void Update()
    {

        // 检测鼠标左键是否被按下
        if (Input.GetMouseButtonDown(1))
        {
            // 从主摄像机发射一条虚拟射线，射线方向是从屏幕上的鼠标位置向场景中发射
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 用于存储射线碰撞到的物体的信息
            RaycastHit hit;
            // 发射射线并检测是否碰撞到物体
            bool isCollide = Physics.Raycast(ray, out hit);
            //Debug.Log("isCollide: " + isCollide);

            // 如果射线碰撞到物体
            if (isCollide)
            {
                if (hit.collider.tag == Tag.GROUND)
                {
                    playerAgent.stoppingDistance = 0;
                    // 将NavMeshAgent的目标位置设置为射线碰撞到的点
                    playerAgent.SetDestination(hit.point);
                }
                else if (hit.collider.tag == Tag.INTERACTABLE)
                {
                    Debug.Log("collider tag:" + hit.collider.tag);

                    //这段代码通常用于处理玩家与可交互对象（如按钮、物品等）的交互。
                    //当玩家点击或碰撞到某个对象时，通过 GetComponent 获取该对象的 InteractableObject 组件，
                    //并触发其 OnClick 方法。
                    hit.collider.GetComponent<InteractableObject>().OnClick(playerAgent);
                }

            }
        }
    }
}
