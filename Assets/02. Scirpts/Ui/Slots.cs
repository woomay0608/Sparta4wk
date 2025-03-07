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
            slots[i].Set();
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
        SelectedItemName.text = slots[index].GetItemInfo().ItemName;
        SelectedItemDescri.text = slots[index].GetItemInfo().ItemDescrip;
        //각각 버튼에 함수 직접 달아주기


    }

    public void ItemInfoTextAndButtonSetDown()
    {
        SelectedItemName.text = string.Empty;
        SelectedItemDescri.text= string.Empty;
        UseEquipBtn.gameObject.SetActive(false);
        RemoveBtn.gameObject.SetActive(false);
    }

}
