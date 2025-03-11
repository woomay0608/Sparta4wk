using System.Collections;
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
            if (!PlayerManager.Instance.PlayerController.IsInvincibilityEffect)
            {
                PlayerManager.Instance.Player.Curhealth -= 1;
                if(PlayerManager.Instance.Player.Curhealth <= 0)
                {
                    PlayerManager.Instance.GameOver();
                }
            }

        }
    }


    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
