using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Consum,
    Other,
    Equipment
}

public enum WhereTheConsum
{
    Health,
    Jump,
    Speed,
    Invincibility
}
public enum WhereTheEquip
{
    Back,
    Shoes
}



[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Item")]
public class ItemInfo : ScriptableObject
{
    public int Id;
    public string ItemName;
    public string ItemDescrip;
    public ItemType Type;
    public WhereTheConsum WhereTheConsum;
    public WhereTheEquip WhereTheEquip;
    public GameObject Prefabs;

    public Sprite Icon;

    public bool IsEquip;

    public bool IsConsumable;
    public int Value;

    public bool IsStack;
 

}
