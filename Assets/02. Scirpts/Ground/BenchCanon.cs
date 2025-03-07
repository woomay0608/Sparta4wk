using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchCanon : MonoBehaviour
{
    public LayerMask layer;
    public GameObject Bullet;
    private void Update()
    {
        Vector3 vector = transform.position + transform.up * 0.5f;
        Ray ray = new Ray(vector, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, new Color(1f,0f,0f));

        RaycastHit hit;
        if(Physics.Raycast(ray,10f,layer))
        {
            Instantiate(Bullet, transform);
            Debug.Log(transform.position + transform.forward * 10f);
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
          
        }
    }
}
