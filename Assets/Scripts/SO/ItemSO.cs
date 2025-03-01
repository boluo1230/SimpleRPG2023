using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public int id;
    public string name;
    public ItemType itemtype;
    public string description;
    public List<ItemProperty> propertylist;
    public Sprite icon;
    public GameObject prefab;
}


public enum ItemType
{
    Weapon,
    Consumable //ÏûºÄÆ·
}

[Serializable]
public class ItemProperty
{
    public ItemPropertyType propertytype;
    public int value;
}


public enum ItemPropertyType
{
    HPValue,
    EnergyValue,
    MentalValue,
    SpeedValue,
    AttackValue
}