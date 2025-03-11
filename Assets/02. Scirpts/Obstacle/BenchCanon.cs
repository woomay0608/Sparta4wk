using System.Collections;
using UnityEngine;

public class BenchCanon : MonoBehaviour
{
    public LayerMask layer;
    public GameObject BulletPrefab;
    private GameObject bullet;
    [Range(0f, 100f)] public float CanonShootCoolTime;
    [Range(0f, 100f)] public float CanonShootPower;

    private bool isOkToShoot = false;


    private void Update()
    {
        Vector3 vector = transform.position + transform.up * 0.5f;
        Ray ray = new Ray(vector, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, new Color(1f,0f,0f));

        RaycastHit hit;
        if(Physics.Raycast(ray,10f,layer))
        {
            StartCoroutine(CanonShoot());
        }
    }


    public IEnumerator CanonShoot()
    {
        if(!isOkToShoot)
        {
            isOkToShoot=true;
            bullet = Instantiate(BulletPrefab,transform);
            bullet.transform.localRotation = Quaternion.identity;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward* CanonShootPower, ForceMode.Impulse);

            yield return new WaitForSeconds(CanonShootCoolTime);
            isOkToShoot = false;

        }
    }
}
