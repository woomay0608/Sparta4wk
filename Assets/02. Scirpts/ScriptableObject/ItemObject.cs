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
    ///////////////����� ��ȣ�ۿ� ��ũ��Ʈ�� ���� �Լ�/////////////////////
    public virtual void OnInteract()
    {

    }

}
