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

    public ParticleSystem Invincibility;

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

    public void JumpCountUP()
    {
        if (JumpCount < 3)
        {
            curJumpCount += 1;
            JumpCount += 1;
            Instantiate(PlayerManager.Instance.PlayerUI.JumpPrefabs, PlayerManager.Instance.PlayerUI.Jump.transform);

        }    
    }
    public void JunpCountDown()
    {
        if (JumpCount > 1)
        {
            curJumpCount -= 1;
            JumpCount -= 1;
            Destroy(PlayerManager.Instance.PlayerUI.Jump.transform.GetChild(PlayerManager.Instance.PlayerUI.Jump.transform.childCount-1).gameObject);
            
        }
    }



}
