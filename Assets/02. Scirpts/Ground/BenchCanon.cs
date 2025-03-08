using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchCanon : MonoBehaviour
{
    public LayerMask layer;
    public GameObject Bullet;
    private GameObject Bullets;
    [Range(0f, 100f)] public float CanonShootCoolTime;
    [Range(0f, 100f)] public float CanonShootPower;

    private bool IsOkToShoot = false;


    private void Update()
    {
        Vector3 vector = transform.position + transform.up * 0.5f;
        Ray ray = new Ray(vector, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, new Color(1f,0f,0f));

        RaycastHit hit;
        if(Physics.Raycast(ray,10f,layer))
        {

            StartCoroutine(CanonShoot());
            //Bullet.GetComponent<Rigidbody>().AddForce(transform.forward,ForceMode.Impulse);
          
        }
    }


    public IEnumerator CanonShoot()
    {
        if(!IsOkToShoot)
        {
            IsOkToShoot=true;
            Bullets = Instantiate(Bullet,transform);
            Bullets.transform.localRotation = Quaternion.identity;
            Bullets.GetComponent<Rigidbody>().AddForce(transform.forward* CanonShootPower, ForceMode.Impulse);

            //틀린코드
            //Instantiate(Bullet,transform);
            //Bullet.GetComponent<Rigidbody>().AddForce(transform.forward* CanonShootPower, ForceMode.Impulse);
            yield return new WaitForSeconds(CanonShootCoolTime);
            IsOkToShoot = false;

        }
    }
}
