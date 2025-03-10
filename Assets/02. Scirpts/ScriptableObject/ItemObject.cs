using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObject : MonoBehaviour
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
    public string GetText()
    {
        return info.InteractText;
    }

    public abstract void OnInteract();
}
