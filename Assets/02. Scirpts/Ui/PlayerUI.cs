using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject Heart;
    [SerializeField] GameObject HeartPrefabs;
    
    public GameObject Jump;
    public GameObject JumpPrefabs;



    private void Start()
    {
        Set();
    }

    private void LateUpdate()
    {
        UiUpdate();
    }

    public void Set()
    {
        for (int i = 0; PlayerManager.Instance.Player.PlayerHealth > i; i++) 
        {
            Instantiate(HeartPrefabs, Heart.transform);
        }
        for(int i = 0; PlayerManager.Instance.Player.JumpCount > i; i++)
        {
            Instantiate(JumpPrefabs, Jump.transform);
        }
    }
    public void UiUpdate()
    {
        
        
        

        int MaxJumpCount  = Jump.transform.childCount;
        int curJumpCount = Mathf.Min(PlayerManager.Instance.Player.CurJumpCount, MaxJumpCount);

        int MaxHeart = Heart.transform.childCount;
        int curHealthCount = Mathf.Min(PlayerManager.Instance.Player.Curhealth, MaxHeart);

        for(int i = 0; i < MaxJumpCount; i++)
        {
            Image jumpImage = Jump.transform.GetChild(i).GetComponent<Image>();
            if (i < curJumpCount)
                jumpImage.color = new Color(1f, 1f, 1f);
            else
                jumpImage.color = new Color(0f, 0f, 0f); 
        }
        for (int i = 0; i < MaxHeart; i++)
        {
            Image HeartImage = Heart.transform.GetChild(i).GetComponent<Image>();
            if (i < curHealthCount)
                HeartImage.color = new Color(1f, 1f, 1f);
            else
                HeartImage.color = new Color(0f, 0f, 0f);
        }





    }
}
