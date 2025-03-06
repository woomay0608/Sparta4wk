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
    private bool IsJump = true;
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
        Debug.Log("Jump");
        if(IsJump)
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        rigidbody.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        IsJump = false;
        yield return new WaitForSeconds(JumpPower/5f);
        IsJump = true;
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
