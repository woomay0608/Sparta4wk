using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{

    public LayerMask layerMask;

    ItemObject itemObject;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Description;


    private void Start()
    {
        
        Name.text = string.Empty;
        Description.text = string.Empty; ;
    }

    private void Update()
    {
        Vector3 RayPosition = transform.position + transform.up * 0.8f;
        Ray ray =  new Ray(RayPosition, transform.forward);
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
                PlayerManager.Instance.Player.Curiteminfo = itemObject.info;
            }
        }
        else
        {
            Name.text = string.Empty;
            Description.text = string.Empty; ;
            PlayerManager.Instance.Player.Curiteminfo = null;
        }
    }


}
