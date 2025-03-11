using UnityEngine;

public class Lamp : ItemObject
{
    Light light;

    private void Start()
    {
         light = GetComponentInChildren<Light>();
    }
    ///////////////상속받아서 상호작용시 실제로 작동되는 로직/////////////////////
    public override void OnInteract()
    {
        light.enabled = !light.enabled;
    }
}
