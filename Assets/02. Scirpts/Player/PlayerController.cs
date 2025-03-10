using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float MoveSpeed;
    private float CurSpeed;
    public Rigidbody Rigidbody;
    public GameObject PlayerBody;
    Vector3 moveDir;
    Animator animator;

    [Header("Jump")]
    public float JumpPower;
    public LayerMask Layer;

    [Header("Camera")]
    public Transform CameraContainer;
    [Range(0,1f)]public float LookSenes;
    [Range(-180f, 180f)] public float MinCamera;
    [Range(-180f, 180f)] public float MaxCamera;
    Vector3 cameraDir;
    float cameraX;

    [Header("Inventory")]
    public GameObject Inventory;

    [Header("Capture")]
    public Slots Slots;

    [Header("Invincibility")]
    public bool IsInvincibility;

    [Header("Wall")]
    public float WallSpeed;
    public bool IsWall = false;

    [Header("Interact")]
    public Action InteractAction;



    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        animator = PlayerBody.GetComponentInChildren<Animator>();
        CurSpeed = MoveSpeed;

    }
    private void FixedUpdate()
    {
        Move();

    }
    private void LateUpdate()
    {
        Look();
    }
    public void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }
    private void Move()
    {
        if (!IsWall)
        {
            Rigidbody.useGravity = true;
            Vector3 n = moveDir.x * transform.right + transform.forward * moveDir.y;
            n *= MoveSpeed;
            n.y = Rigidbody.velocity.y;
            Rigidbody.velocity = n;
            animator.SetBool("IsMoving", moveDir.magnitude > 0);
        }
        else
        {
            Rigidbody.useGravity = false;
            Vector3 n = moveDir.y * transform.up + transform.right *moveDir.x ;
            n *= WallSpeed;
            Rigidbody.velocity = n;
        }
        
        
    }

    public void OnJump()
    {
        if(PlayerManager.Instance.IsPlayerGround)
        {
            Jump();
        }
        else
        {
            Jump();
        }

        
    }

    private void Jump()
    {
        if(PlayerManager.Instance.Player.CurJumpCount == 0) 
        {
            return; 
        }
        else
        {
       
            Rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            animator.SetTrigger("IsJump");
            PlayerManager.Instance.Player.CurJumpCount--;
        }
        
    }
    public void OnLook(InputValue value)
    {
        cameraDir = value.Get<Vector2>();
    }

    private void Look()
    {
        cameraX += cameraDir.y * LookSenes;
        cameraX = Mathf.Clamp(cameraX, MinCamera, MaxCamera);
        CameraContainer.localEulerAngles = new Vector3(-cameraX, 0f, 0f);
        transform.eulerAngles += new Vector3(0f, cameraDir.x * LookSenes, 0f);


        //CameraContainer.transform.eulerAngles += new Vector3(-CameraDir.x, 0f, 0f);
    }

    public void OnCapture()
    {
        if(PlayerManager.Instance.Player.Curiteminfo != null) 
        {
            Debug.Log("Good");
            Slots.CapturedItemToInvetory(PlayerManager.Instance.Player.Curiteminfo);
        }
    }
    public void OnInteract()
    {
        if (PlayerManager.Instance.Player.Curiteminfo != null && PlayerManager.Instance.Player.Curiteminfo.Type == ItemType.Other)
        {
            if(InteractAction != null)
            InteractAction();
        }
    }

    public void OnInventory()
    {
        if(Inventory.gameObject.activeInHierarchy)
        {
            Inventory.gameObject.SetActive(false);
        }
        else
        {
            Inventory.gameObject.SetActive(true);
        }

    }

    private IEnumerator JumpCountUp()
    {
        PlayerManager.Instance.Player.JumpCountUP();
        yield return new WaitForSeconds(3f);
        PlayerManager.Instance.Player.JunpCountDown();
    }
    public void StartJumpCountUp()
    {
        StartCoroutine(JumpCountUp());
    }

    private IEnumerator Speedup()
    {
        MoveSpeed = CurSpeed + 3f;
        yield return new WaitForSeconds(10f);
        Debug.Log("hii");
        MoveSpeed = CurSpeed;
    }

    public void StartSpeedup()
    {
        StartCoroutine(Speedup());
    }


    private IEnumerator Invincibility()
    {
        IsInvincibility = true;
        PlayerManager.Instance.Player.Invincibility.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        IsInvincibility = false;
        PlayerManager.Instance.Player.Invincibility.gameObject.SetActive(false);

    }

    public void StartInvincibility()
    {
        StartCoroutine(Invincibility());
    }




}
