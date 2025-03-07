using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndiSlot : MonoBehaviour
{


    public int index;
    public Image icon;
    public bool SomeItemComein = false;
    ItemInfo itemInfo;


    public void SetIteminfo(ItemInfo itemInfos)
    {
        itemInfo = itemInfos;
    }
 
}
