using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    private GameObject uiGameObject;
    private GameObject content;
    private GameObject itemPrefab;

    //单例模式
    public static InventoryUI Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        uiGameObject = transform.Find("UI").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        uiGameObject.SetActive(true);
    }

    public void Hide()
    {
        uiGameObject.SetActive(false);
    }

    public void AddItem(ItemSO itemSO)
    {
        GameObject itemGo = GameObject.Instantiate(itemPrefab);
        itemGo.transform.parent = content.transform;
        ItemUI itemUI = itemGo.GetComponent<ItemUI>();

        string type = "";
        switch (itemSO.itemtype)
        {
            case ItemType.Weapon:
                type = "武器";
                break;

            case ItemType.Consumable:
                type = "可消耗品";
                break;
        }

        itemUI.InitItem(itemSO.icon, itemSO.name, type);
    }

}
