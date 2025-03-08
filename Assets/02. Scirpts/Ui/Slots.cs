using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public IndiSlot[] slots;

    [SerializeField] private Button UseEquipBtn;
    [SerializeField] private Button RemoveBtn;
    [SerializeField] private TextMeshProUGUI SelectedItemName;
    [SerializeField] private TextMeshProUGUI SelectedItemDescri;
    [SerializeField] private ItemInfo Default;
    private void Start()
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            slots[i].index = i;
            slots[i].Count.text = string.Empty;
        }
        ItemInfoTextAndButtonSetDown();
    }
    private void Update()
    {
        for(int i = 0;i < slots.Length;i++)
        {
            if (slots[i].GetItemInfo() != null)
                slots[i].Set();
            else 
                slots[i].Clear();

            if(i >=1)
            {
                if (slots[i-1].GetItemInfo() == null)
                {
                    slots[i - 1].SetIteminfo(slots[i].GetItemInfo());
                    slots[i - 1].itemCount = slots[i].itemCount;
                    slots[i-1].Set();
                    slots[i].Clear();
                }
            }

        }
    
        
    }

    public void CapturedItemToInvetory(ItemInfo itemInfo)
    {
        for (int i = 0;i < slots.Length;i++) 
        {
            if (slots[i].SomeItemComein)
            {
                if (itemInfo.IsStack&& slots[i].GetItemInfo().Id == itemInfo.Id)
                {
                    slots[i].itemCount += 1;
                    break;
                }
                else if(IsSameItemInBackPack(itemInfo))
                {
                    break;
                }
                continue;
            }
            else
            {
                slots[i].SetIteminfo(itemInfo);
                slots[i].icon.sprite =itemInfo.Icon;
                if(slots[i].GetItemInfo().IsStack)
                {
                    slots[i].itemCount++;
                    slots[i].Count.text = slots[i].itemCount.ToString();
                }
                slots[i].SomeItemComein = true;
                break;
            }
          
        }
    }



    private bool IsSameItemInBackPack(ItemInfo itemInfo)
    {
        for(int i = 0 ;i < slots.Length;i++)
        {
            if (slots[i].GetItemInfo().Id == itemInfo.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }


    public void SelectItem(int index)
    {
        if (slots[index].GetItemInfo() == null)
        {
            ItemInfoTextAndButtonSetDown();
            return;
        }

        PlayerManager.Instance.Player.SetIndiSlot(slots[index]);
        Selected(index);
        SelectedItemName.text = PlayerManager.Instance.Player.slot.GetItemInfo().ItemName;
        SelectedItemDescri.text = PlayerManager.Instance.Player.slot.GetItemInfo().ItemDescrip;
        //각각 버튼에 함수 직접 달아주기
        UseEquipBtn.gameObject.SetActive(true);
        RemoveBtn.gameObject.SetActive(true);
        if (slots[index].GetItemInfo().Type == ItemType.Consum)
        { 
            UseEquipBtn.onClick.RemoveAllListeners();
            UseEquipBtn.onClick.AddListener(() => SlotItemuse(PlayerManager.Instance.Player.slot));

            RemoveBtn.onClick.RemoveAllListeners();
            RemoveBtn.onClick.AddListener(() => RemoveItem(PlayerManager.Instance.Player.slot));
        }

    }

    public void ItemInfoTextAndButtonSetDown()
    {
        SelectedItemName.text = string.Empty;
        SelectedItemDescri.text= string.Empty;
        UseEquipBtn.gameObject.SetActive(false);
        RemoveBtn.gameObject.SetActive(false);
    }

    public void Selected(int index)
    {
        for(int i = 0; i < slots.Length; i++) 
        {
            slots[i].Selected = false;
            slots[i].OnOutline();
        }
        slots[index].Selected = true;
        slots[index].OnOutline();
    }



    private void RemoveItem(IndiSlot indi)
    {
        indi.itemCount--;
        if(indi.itemCount == 0)
        {
            indi.Clear();
            ItemInfoTextAndButtonSetDown();
        }
      
    }

    private void SlotItemThrow(IndiSlot indi)
    {
        RemoveItem(indi);
    }
    private void SlotItemuse(IndiSlot indi)
    {
        if(indi.GetItemInfo().Type == ItemType.Consum)
        {
            if(indi.GetItemInfo().WhereTheConsum == WhereTheConsum.Health)
            {
                PlayerManager.Instance.Player.curhealth += 1;
                RemoveItem(indi);
                if (PlayerManager.Instance.Player.curhealth > PlayerManager.Instance.Player.PlayerHealth)
                {
                    PlayerManager.Instance.Player.curhealth = PlayerManager.Instance.Player.PlayerHealth;
                }
            }
            else if (indi.GetItemInfo().WhereTheConsum == WhereTheConsum.Jump)
            {
                PlayerManager.Instance.PlayerUI.PlusJumpCount();
                RemoveItem(indi);
            }
            else if(indi.GetItemInfo().WhereTheConsum == WhereTheConsum.Speed)
            {
                PlayerManager.Instance.PlayerController.StartSpeedup();
                RemoveItem(indi);
            }
        }

        //장비는 나중에 추가할 예정
    }

}
