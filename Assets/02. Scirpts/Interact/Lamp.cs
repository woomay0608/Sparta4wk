using UnityEngine;

public class Lamp : ItemObject
{
    Light light;

    private void Start()
    {
         light = GetComponentInChildren<Light>();
    }
    ///////////////��ӹ޾Ƽ� ��ȣ�ۿ�� ������ �۵��Ǵ� ����/////////////////////
    public override void OnInteract()
    {
        light.enabled = !light.enabled;
    }
}
