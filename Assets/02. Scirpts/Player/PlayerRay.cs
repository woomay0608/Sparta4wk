using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{

    public LayerMask LayerMask;
    public LayerMask WallLayer;
    public float Angle;
    ItemObject itemObject;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private GameObject TxtPrefab;
    GameObject txtObject;
    bool IsTextOk = true;
    bool IsDestroyOk = false;
    public Ray ray;
    public RaycastHit hit;

    public float Height;
    float WallJump; 
    private void Start()
    {
        
        Name.text = string.Empty;
        Description.text = string.Empty; ;
    }

    private void Update()
    {
        Vector3 RayPosition = transform.position + transform.up * 0.8f;
        ray =  new Ray(RayPosition, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction);
        ShowItemNameAndDescriptionToRay(out hit,ray);



    }



    private void ShowItemNameAndDescriptionToRay(out RaycastHit hit, Ray ray)
    {
        if (Physics.Raycast(ray, out hit, 1f ,LayerMask))
        {
            if (hit.transform.TryGetComponent(out itemObject))
            {

                StartCoroutine(SetText());
                IsTextOk = false;
                IsDestroyOk = false;
                Name.text = itemObject.GetName();
                Description.text = itemObject.GetDescription();
                PlayerManager.Instance.Player.Curiteminfo = itemObject.info;
                if(itemObject.info.Type == ItemType.Other)
                {
                    PlayerManager.Instance.PlayerController.InteractAction = itemObject.OnInteract;
                }
            }
        }
        else
        {
            if(txtObject != null)
                Destroy(txtObject);
            IsTextOk = true;
            IsDestroyOk = true;
            Name.text = string.Empty;
            Description.text = string.Empty;
             
            PlayerManager.Instance.Player.Curiteminfo = null;
        }
    }


    public void wallRide(out RaycastHit hit, Ray ray)
    {
        if(Physics.Raycast(ray, out hit, 0.5f, WallLayer))
        {
            Angle = Vector3.Angle(hit.normal, Vector3.up);
            if(Angle > 80&& Angle < 100)
            {
                PlayerManager.Instance.PlayerController.Rigidbody.velocity = Vector3.zero;
                PlayerManager.Instance.PlayerController.IsWall = true;
                BoxCollider Collider = hit.transform.GetComponent<BoxCollider>();
                Height = Collider.bounds.size.y;
                WallJump = Collider.bounds.min.y + (0.90f * Height);
                if (WallJump <=  ray.origin.y)
                {
                    PlayerManager.Instance.PlayerUI.IsOkWallRideUISetActive();
                }
                else
                {
                    PlayerManager.Instance.PlayerUI.IsOkWallRideUISetUnActive();
                }
            }
        }
        else
        {
     
            PlayerManager.Instance.PlayerController.IsWall= false;
        }
    }

    public void JumpOverWall(float Height) 
    {
        PlayerManager.Instance.Player.transform.position = new Vector3(PlayerManager.Instance.Player.transform.position.x + 1f,
    PlayerManager.Instance.Player.transform.position.y + Mathf.Abs(Height * 0.10f) + 1f, PlayerManager.Instance.Player.transform.position.z);
    }

    private IEnumerator SetText()
    {
        if (IsTextOk)
        {
            txtObject = Instantiate(TxtPrefab, itemObject.transform);
            txtObject.GetComponent<InteractiveText>().SetCommandText(itemObject.GetText());
        }
        yield return new WaitUntil(() =>IsDestroyOk );
        
    }




}
