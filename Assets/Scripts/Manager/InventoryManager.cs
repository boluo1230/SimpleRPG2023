using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//单例模式 
//用来存放player捡起来的数据
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    public List<ItemSO> itemList;

    public void AddItem(ItemSO item)
    {
        if (itemList == null)
        {
            itemList = new List<ItemSO>();
        }
        
        itemList.Add(item);
    }

}
