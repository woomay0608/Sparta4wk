using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator animator;
    public GameObject PlayerBody;


    Vector3 MoveDir;
    [Header("Move")]
    public float MoveSpeed;
    private float CurSpeed;

    [Header("Jump")]
    public float JumpPower;
    public LayerMask Layer;

    
    Vector3 CameraDir;
    float CameraX;
    [Header("Camera")]
    public Transform CameraContainer;
    [Range(0,1f)]public float LookSenes;
    [Range(-180f, 180f)] public float MinCamera;
    [Range(-180f, 180f)] public float MaxCamera;

    [Header("Inventory")]
    public GameObject Inventory;

    [Header("Capture")]
    public Slots Slots;

    [Header("Invincibility")]
    public bool IsInvincibility;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
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
        MoveDir = value.Get<Vector2>();
    }
    private void Move()
    {
        Vector3 n = MoveDir.x * transform.right + transform.forward * MoveDir.y;
        n *= MoveSpeed;
        n.y = rigidbody.velocity.y;
        rigidbody.velocity = n;
        
        animator.SetBool("IsMoving", MoveDir.magnitude > 0);
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
        if(PlayerManager.Instance.Player.curJumpCount == 0) 
        {
            return; 
        }
        else
        {
       
            rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            animator.SetTrigger("IsJump");
            PlayerManager.Instance.Player.curJumpCount--;
        }
        
    }
    public void OnLook(InputValue value)
    {
        CameraDir = value.Get<Vector2>();
    }

    private void Look()
    {
        CameraX += CameraDir.y * LookSenes;
        CameraX = Mathf.Clamp(CameraX, MinCamera, MaxCamera);
        CameraContainer.localEulerAngles = new Vector3(-CameraX, 0f, 0f);
        transform.eulerAngles += new Vector3(0f, CameraDir.x * LookSenes, 0f);


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
