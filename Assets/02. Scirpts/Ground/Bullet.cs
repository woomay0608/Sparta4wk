using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!PlayerManager.Instance.PlayerController.IsInvincibility)
            PlayerManager.Instance.Player.curhealth -= 1;

        }
    }


    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
