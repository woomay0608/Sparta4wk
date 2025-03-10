using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PlayerInfo")]
    public int PlayerHealth;
    public int Curhealth;
    public int JumpCount;
    public int CurJumpCount;
    [Header("PlayerItemInfo")]
    public ItemInfo Curiteminfo;
    public IndiSlot Slot;
    [Header("Other")]
    public ParticleSystem Invincibility;
    public GameObject Back;

    private void Start()
    {
        Curhealth = PlayerHealth;
        CurJumpCount = JumpCount;
    }


    public void SetJumpCount()
    {
        CurJumpCount = JumpCount;
    }
    public void SetIndiSlot(IndiSlot indi)
    {
        Slot = indi;
        
    }

    public void JumpCountUP()
    {
        if (JumpCount < 3)
        {
            CurJumpCount += 1;
            JumpCount += 1;
            Instantiate(PlayerManager.Instance.PlayerUI.JumpPrefabs, PlayerManager.Instance.PlayerUI.Jump.transform);

        }    
    }
    public void JunpCountDown()
    {
        if (JumpCount > 1)
        {
            CurJumpCount -= 1;
            JumpCount -= 1;
            Destroy(PlayerManager.Instance.PlayerUI.Jump.transform.GetChild(PlayerManager.Instance.PlayerUI.Jump.transform.childCount-1).gameObject);
            
        }
    }



}
