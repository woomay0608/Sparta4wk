using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Consum,
    Other
}

public enum WhereTheConsum
{
    Health,
    Jump
}


[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Item")]
public class ItemInfo : ScriptableObject
{
    public string ItemName;
    public string ItemDescrip;
    public ItemType Type;
    public GameObject Prefabs;

    public Sprite Icon;


    public bool IsConsumable;
    public int Value;
}
