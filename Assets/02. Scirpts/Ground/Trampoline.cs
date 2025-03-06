using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    Rigidbody body;

    [Range(0, 100)] public int TrampolinePower;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 normal = collision.contacts[0].normal;
            Vector3 Reflact = Vector3.Reflect(rb.velocity, normal);
            rb.velocity = TrampolinePower * Reflact;
        }
    }

}
