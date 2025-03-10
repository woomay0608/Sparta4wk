using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ground : MonoBehaviour
{

    public bool IsBake = false;
    public AI aI;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") || collision.collider.CompareTag("AI"))
        {
            PlayerManager.Instance.IsPlayerGround = true;
            PlayerManager.Instance.Player.SetJumpCount();
            collision.transform.parent = transform;
            if(IsBake)
            {
                aI.SurfaceBake();
            }
        
        }

    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("AI"))
        {
            PlayerManager.Instance.IsPlayerGround = false;
            collision.transform.parent = null;
        }
    }

}
