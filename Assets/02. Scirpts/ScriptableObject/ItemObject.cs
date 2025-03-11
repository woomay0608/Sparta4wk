using UnityEngine;

public  class ItemObject : MonoBehaviour
{
    public ItemInfo info;

    public string GetName()
    {
        return info.name;
    }
    public string GetDescription()
    {
        return info.ItemDescrip;
    }
    public string GetText()
    {
        return info.InteractText;
    }
    ///////////////전등같은 상호작용 스크립트를 위한 함수/////////////////////
    public virtual void OnInteract()
    {

    }

}
