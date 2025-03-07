using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    private IndiSlot[] slots;


    private void Start()
    {
        slots = new IndiSlot[transform.childCount];
        for (int i = 0; i < slots.Length; i++) 
        {
            slots[i].index = i;
        }
    }

}
