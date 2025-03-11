using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public IndiSlot[] SlotArray;

    [SerializeField] private Button UseEquipBtn;
    [SerializeField] private Button RemoveBtn;
    [SerializeField] private Button UnEquipButton;
    [SerializeField] private TextMeshProUGUI SelectedItemName;
    [SerializeField] private TextMeshProUGUI SelectedItemDescri;
   
    private void Start()
    {
        for (int i = 0; i < SlotArray.Length; i++) 
        {
            SlotArray[i].Index = i;
            SlotArray[i].TxtCount.text = string.Empty;
        }
        ItemInfoTextAndButtonSetDown();
    }

    ///////////////�ֱ������� UI ���� �� ������� ä��� �Լ�/////////////////////
    private void Update()
    {
        for(int i = 0;i < SlotArray.Length;i++)
        {
            if (SlotArray[i].GetItemInfo() != null)
                SlotArray[i].SetSlot();
            else 
                SlotArray[i].ClearSlot();

            if(i >=1)
            {
                if (SlotArray[i-1].GetItemInfo() == null)
                {
                    SlotArray[i - 1].SetIteminfo(SlotArray[i].GetItemInfo());
                    SlotArray[i - 1].ItemCount = SlotArray[i].ItemCount;
                    SlotArray[i-1].SetSlot();
                    SlotArray[i].ClearSlot();
                }
            }

        }
    
        
    }

    ///////////////�ߺ�/stack üũ �� �κ��丮�� �ִ� �Լ�/////////////////////
    public void CapturedItemToInvetory(ItemInfo itemInfo)
    {
        for (int i = 0;i < SlotArray.Length;i++) 
        {
            if (SlotArray[i].SomeItemComein)
            {
                if (itemInfo.IsStack&& SlotArray[i].GetItemInfo().Id == itemInfo.Id)
                {
                    SlotArray[i].ItemCount += 1;
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
                SlotArray[i].SetIteminfo(itemInfo);
                SlotArray[i].Icon.sprite =itemInfo.Icon;
                if(SlotArray[i].GetItemInfo().IsStack)
                {
                    SlotArray[i].ItemCount++;
                    SlotArray[i].TxtCount.text = SlotArray[i].ItemCount.ToString();
                }
                SlotArray[i].SomeItemComein = true;
                break;
            }
          
        }
    }


    ///////////////���� �������� �ִ��� �Ǵ� �Լ�/////////////////////
    private bool IsSameItemInBackPack(ItemInfo itemInfo)
    {
        for(int i = 0 ;i < SlotArray.Length;i++)
        {
            if (SlotArray[i].GetItemInfo().Id == itemInfo.Id)
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

    ///////////////������ ���ý� Ư�� ��ư�� �ؽ�Ʈ ���� �Լ�/////////////////////
    public void SelectItem(int index)
    {
        if (SlotArray[index].GetItemInfo() == null)
        {
            ItemInfoTextAndButtonSetDown();
            return;
        }

        PlayerManager.Instance.Player.SetIndiSlot(SlotArray[index]);
        Selected(index);
        SelectedItemName.text = PlayerManager.Instance.Player.Slot.GetItemInfo().ItemName;
        SelectedItemDescri.text = PlayerManager.Instance.Player.Slot.GetItemInfo().ItemDescrip;
        //���� ��ư�� �Լ� ���� �޾��ֱ�

        if (SlotArray[index].GetItemInfo().IsEquip)
        {
            UnEquipButton.gameObject.SetActive(true);
            UseEquipBtn.gameObject.SetActive(false);
            UnEquipButton.onClick.RemoveAllListeners();
            UnEquipButton.onClick.AddListener(()=> SlotItemUnEquip(PlayerManager.Instance.Player.Slot));
        }
        else
        {
            UnEquipButton.gameObject.SetActive(false);
            UseEquipBtn.gameObject.SetActive(true);
            UseEquipBtn.onClick.RemoveAllListeners();
            UseEquipBtn.onClick.AddListener(() => SlotItemuse(PlayerManager.Instance.Player.Slot));
        }
 
        RemoveBtn.gameObject.SetActive(true);
        RemoveBtn.onClick.RemoveAllListeners();
        RemoveBtn.onClick.AddListener(() => RemoveItem(PlayerManager.Instance.Player.Slot));

    }
    ///////////////�κ��丮 ���� ���� �Լ�/////////////////////
    public void ItemInfoTextAndButtonSetDown()
    {
        SelectedItemName.text = string.Empty;
        SelectedItemDescri.text= string.Empty;
        UseEquipBtn.gameObject.SetActive(false);
        UnEquipButton.gameObject.SetActive(false);
        RemoveBtn.gameObject.SetActive(false);
    }
    ///////////////�����ϰ� �ƿ����� ���� �Լ�/////////////////////
    public void Selected(int index)
    {
        for(int i = 0; i < SlotArray.Length; i++) 
        {
            SlotArray[i].Selected = false;
            SlotArray[i].OnOutline();
        }
        SlotArray[index].Selected = true;
        SlotArray[index].OnOutline();
    }


    ///////////////������ ����� �Լ�/////////////////////
    private void RemoveItem(IndiSlot indi)
    {
        indi.ItemCount--;
        if(indi.ItemCount <= 0)
        {
            if(indi.GetItemInfo().IsEquip)
            {
                SlotItemUnEquip(indi);
            }
            indi.ClearSlot();
            ItemInfoTextAndButtonSetDown();
        }
      
    }
    ///////////////�������� �Լ�/////////////////////
    private void SlotItemUnEquip(IndiSlot indi)
    {
        if(indi.GetItemInfo().WhereTheEquip == WhereTheEquip.Back)
        {
            Destroy(PlayerManager.Instance.Player.transform.GetChild(2).transform.GetChild(0).gameObject);
            PlayerManager.Instance.Player.JunpCountDown();
        }
    }
    ///////////////���/ ����  �Լ�/////////////////////
    private void SlotItemuse(IndiSlot indi)
    {
        if(indi.GetItemInfo().Type == ItemType.Consum)
        {
            if(indi.GetItemInfo().WhereTheConsum == WhereTheConsum.Health)
            {
                PlayerManager.Instance.Player.Curhealth += 1;
                RemoveItem(indi);
                if (PlayerManager.Instance.Player.Curhealth > PlayerManager.Instance.Player.PlayerHealth)
                {
                    PlayerManager.Instance.Player.Curhealth = PlayerManager.Instance.Player.PlayerHealth;
                }
            }
            else if (indi.GetItemInfo().WhereTheConsum == WhereTheConsum.Jump)
            {
                PlayerManager.Instance.PlayerController.StartJumpCountUp();
                RemoveItem(indi);
            }
            else if(indi.GetItemInfo().WhereTheConsum == WhereTheConsum.Speed)
            {
                PlayerManager.Instance.PlayerController.StartSpeedup();
                RemoveItem(indi);
            }
            else if(indi.GetItemInfo().WhereTheConsum == WhereTheConsum.Invincibility)
            {
                PlayerManager.Instance.PlayerController.StartInvincibility();
                RemoveItem(indi);
            }
        }
        else if(indi.GetItemInfo().Type == ItemType.Equipment)
        {
            if(indi.GetItemInfo().WhereTheEquip == WhereTheEquip.Back)
            {
                Instantiate(indi.GetItemInfo().Prefabs, PlayerManager.Instance.Player.Back.transform);
                indi.GetItemInfo().IsEquip = true;
                PlayerManager.Instance.Player.JumpCountUP();
            }
        }
    }

}
