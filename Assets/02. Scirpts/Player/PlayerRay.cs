using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{

    Camera cam;
    public LayerMask layerMask;

    ItemObject itemObject;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Description;


    private void Start()
    {
        cam = Camera.main;
        Name.text = string.Empty;
        Description.text = string.Empty; ;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2));
        Debug.DrawRay(ray.origin, ray.direction);
        RaycastHit hit;
        ShowItemNameAndDescriptionToRay(out hit,ray);

    }



    private void ShowItemNameAndDescriptionToRay(out RaycastHit hit, Ray ray)
    {
        if (Physics.Raycast(ray, out hit, 1f ,layerMask))
        {
            if (hit.transform.TryGetComponent(out itemObject))
            {
                Name.text = itemObject.GetName();
                Description.text = itemObject.GetDescription();
            }
        }
        else
        {
            Name.text = string.Empty;
            Description.text = string.Empty; ;
        }
    }


}
