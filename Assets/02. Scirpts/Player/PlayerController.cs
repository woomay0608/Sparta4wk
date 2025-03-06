using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;

    //이동 관련
    Vector3 MoveDir;
    public float MoveSpeed;
    //점프 관련
    public float JumpPower;
    int Jumpc;
    public LayerMask Layer;
    //카메라
    Vector3 CameraDir;
    public Transform CameraContainer;
    float CameraX;
    [Range(0,1f)]public float LookSenes;
    [Range(-180f, 180f)] public float MinCamera;
    [Range(-180f, 180f)] public float MaxCamera;

    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        Debug.DrawRay(transform.forward, new Vector3(0f, -1f, 0f), new Color(1f,1f,0f));
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




}
