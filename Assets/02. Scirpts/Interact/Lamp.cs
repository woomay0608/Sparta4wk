using UnityEngine;

public class Lamp : ItemObject
{
    Light light;

    private void Start()
    {
         light = GetComponentInChildren<Light>();
    }
    public override void OnInteract()
    {
        light.enabled = !light.enabled;
    }
}
