using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int PlayerHealth;
    public int curhealth;
    public int JumpCount;
    public int curJumpCount;

    public ItemInfo Curiteminfo;
    public IndiSlot slot;

    private void Start()
    {
        curhealth = PlayerHealth;
        curJumpCount = JumpCount;
    }

    public void SetJumpCount()
    {
        curJumpCount = JumpCount;
    }
    public void SetIndiSlot(IndiSlot indi)
    {
        slot = indi;
        
    }



}
