using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject Heart;
    [SerializeField] GameObject HeartPrefabs;
    
    [SerializeField] GameObject Jump;
    [SerializeField] GameObject JumpPrefabs;


    private void Start()
    {
        Set();
    }

    private void Update()
    {
        UiUpdate();
    }

    private void Set()
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

    public void PlusJumpCount()
    {
        if(PlayerManager.Instance.Player.JumpCount >= 3)
        {
            return;
        }
        Instantiate(JumpPrefabs, Jump.transform);
        PlayerManager.Instance.Player.JumpCount += 1;
    }



    public void UiUpdate()
    {
        
        int UnActiveheartChild = Heart.transform.childCount - PlayerManager.Instance.Player.curhealth;
        int UnActivejumpChild = Jump.transform.childCount - PlayerManager.Instance.Player.curJumpCount;

        

        for (int i = 0;  i < UnActiveheartChild; i++)
        {
            Heart.transform.GetChild(Heart.transform.childCount - i-1).GetComponent<Image>().color = new Color(0f,0f,0f); 
        }
        for (int i = 0; i < UnActivejumpChild; i++)
        {
            Jump.transform.GetChild(Jump.transform.childCount - i -1).GetComponent<Image>().color = new Color(0f, 0f, 0f);
        }
        for (int i = 0; i < PlayerManager.Instance.Player.curhealth; i++)
        {
            Heart.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
        for (int i = 0; i < PlayerManager.Instance.Player.curJumpCount; i++)
        {
            Jump.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }


    }
}
