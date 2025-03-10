using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndiSlot : MonoBehaviour
{

    [Header("ItemInfo")]
    public int Index;
    public Image Icon;
    public bool SomeItemComein = false;
    public int ItemCount = 0;
    public TextMeshProUGUI TxtCount;

    private Outline outline;
    ItemInfo itemInfo;
    private Button selectItem;
    private Slots slots;
    public bool Selected;
    


    private void Start()
    {
        outline = GetComponent<Outline>();
        selectItem = GetComponent<Button>();
        slots = GetComponentInParent<Slots>(true);
        selectItem.onClick.AddListener(OnClickMe);
    }

    public void OnOutline()
    {
        outline.enabled = Selected;
    }
    public void SetIteminfo(ItemInfo itemInfos)
    {
        itemInfo = itemInfos;
    }
    public ItemInfo GetItemInfo()
    {
        return itemInfo;
    }

    public void SetSlot()
    {
        if(itemInfo != null) 
        {
            Icon.gameObject.SetActive(true);
            Icon.sprite = itemInfo.Icon;
            TxtCount.text = ItemCount > 0 ? ItemCount.ToString() : string.Empty;
        }
    }

    public void ClearSlot()
    {
        SetIteminfo(null);
        SomeItemComein = false;
        TxtCount.text = string.Empty;
        Icon.gameObject.SetActive(false);

    }

    public void OnClickMe()
    {
        slots.SelectItem(Index);
    }


 
}
