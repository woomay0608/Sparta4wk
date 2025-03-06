using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody rigidbody;

    Vector3 dir;
    public float MoveSpeed;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 n = dir.x * transform.right +transform.forward * dir.y;
        n *=  MoveSpeed;
        n.y = rigidbody.velocity.y;
        rigidbody.velocity = n;

    }


    public void OnMove(InputValue value)
    {
        dir = value.Get<Vector2>();

        Debug.Log($"{dir.x} {dir.y}");

        
 
    }

}
