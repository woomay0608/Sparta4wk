using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            PlayerManager.Instance.IsPlayerGround = true;
            PlayerManager.Instance.Player.SetJumpCount();
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerManager.Instance.IsPlayerGround = false;
        }
    }

}
