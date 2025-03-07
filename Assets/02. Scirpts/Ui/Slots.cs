using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public IndiSlot[] slots;
    private void Start()
    {
        
        for (int i = 0; i < slots.Length; i++) 
        {
            slots[i].index = i;
        }
    }

    public void CapturedItemToInvetory(ItemInfo itemInfo)
    {
        for (int i = 0;i < slots.Length;i++) 
        {
            if (slots[i].SomeItemComein)
            {
                continue;
            }
            else
            {
                slots[i].icon.sprite =itemInfo.Icon;
                slots[i].SomeItemComein = true;
                break;
            }
          
        }
    }

}
