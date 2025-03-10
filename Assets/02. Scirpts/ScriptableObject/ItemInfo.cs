using UnityEngine;


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
    [Header("Item Basic Info")]
    public int Id;
    public string ItemName;
    public string ItemDescrip;
    public GameObject Prefabs;
    [Header("Item Type Info")]
    public ItemType Type;
    public WhereTheConsum WhereTheConsum;
    public WhereTheEquip WhereTheEquip;

    [Header("UI")]
    public Sprite Icon;
    public string InteractText;
    [Header("Other")]
    public bool IsEquip;
    public bool IsConsumable;
    public int Value;
    public bool IsStack;
 

}
