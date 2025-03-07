using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemInfo info;

    public string GetName()
    {
        return info.name;
    }
    public string GetDescription()
    {
        return info.ItemDescrip;
    }
}
