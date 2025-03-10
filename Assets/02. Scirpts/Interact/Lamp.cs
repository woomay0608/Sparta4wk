using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : ItemObject
{
    Light Light;

    private void Start()
    {
         Light = GetComponentInChildren<Light>();
    }
    public override void OnInteract()
    {
        Light.enabled = !Light.enabled;
    }
}
