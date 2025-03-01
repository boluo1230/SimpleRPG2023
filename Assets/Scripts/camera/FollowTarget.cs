using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
1.offset:
`用于存储当前对象与玩家之间的初始距离（偏移量）。
`在 Start 方法中计算得出。

2.playerTransform:
`存储玩家的 Transform 组件，用于获取玩家的位置。

3.Start 方法:
`在游戏开始时运行，初始化 playerTransform 和 offset。

4.Update 方法:
`每帧更新当前对象的位置，使其始终与玩家保持初始的偏移量，从而实现跟随效果。

这段代码通常用于实现相机跟随玩家或其他对象的功能。
 */
public class FollowTarget : MonoBehaviour
{
    // 偏移量
    private Vector3 offset;
    // 玩家的Transform组件
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        // 查找带有"Player"标签的游戏对象，并获取其Transform组件
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        // 计算当前对象与玩家之间的初始偏移量
        offset = transform.position - playerTransform.position;
        //Debug.Log("offset: " + offset);
    }

    // Update is called once per frame
    void Update()
    {
        // 更新当前对象的位置，使其跟随玩家并保持初始偏移量
        transform.position = playerTransform.position + offset;
    }
}
