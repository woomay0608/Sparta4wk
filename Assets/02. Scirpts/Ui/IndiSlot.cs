using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndiSlot : MonoBehaviour
{

    [Header("ItemInfo")]
    public int index;
    public Image icon;
    public bool SomeItemComein = false;
    public int itemCount = 0;
    public TextMeshProUGUI Count;

    private Outline outline;
    ItemInfo itemInfo;
    private Button SelectItem;
    private Slots slots;
    public bool Selected;
    


    private void Start()
    {
        outline = GetComponent<Outline>();
        SelectItem = GetComponent<Button>();
        slots = GetComponentInParent<Slots>(true);

        SelectItem.onClick.AddListener(OnClickMe);
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

    public void Set()
    {
        if(itemInfo != null) 
        {
            icon.gameObject.SetActive(true);
            icon.sprite = itemInfo.Icon;
            Count.text = itemCount > 0 ? itemCount.ToString() : string.Empty;
        }
    }

    public void Clear()
    {
        SetIteminfo(null);
        SomeItemComein = false;
        Count.text = string.Empty;
        icon.gameObject.SetActive(false);

    }

    public void OnClickMe()
    {
        slots.SelectItem(index);
    }


 
}
