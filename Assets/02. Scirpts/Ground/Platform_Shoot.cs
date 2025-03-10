using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Shoot : MonoBehaviour
{
    [SerializeField] float WatingTime;
    [SerializeField][Range(-100f,100f)] float x;
    [SerializeField][Range(-50f, 50f)] float y;
    [SerializeField][Range(-100f, 100f)] float z;

    Animator animator;
    BoxCollider collider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Rigidbody rb = collision.transform.GetComponent<Rigidbody>();
            StartCoroutine(Silhum(rb));
        }
    }

    private IEnumerator Silhum(Rigidbody rigidbody)
    {

        yield return new WaitForSeconds(WatingTime);
        animator.SetBool("Up", true);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(Mathf.Abs((x+y+z)/((x+y+z)*50)));
            rigidbody.AddForce(new Vector3(x, y/10, z), ForceMode.Impulse);
        }
        animator.SetBool("Up", false);
    }

}


