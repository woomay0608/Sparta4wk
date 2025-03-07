using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemInfo info;
    [HideInInspector]
    public string ItemName;
    [HideInInspector]
    public string ItemDesription;
    ItemType ItemType;


    void Start()
    {
        ItemType = info.Type;
        ItemName = info.ItemName;
        ItemDesription = info.ItemDescrip;
    }
}
