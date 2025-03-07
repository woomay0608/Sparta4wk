using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            PlayerManager.Instance.IsPlayerGround = true;
            PlayerManager.Instance.Player.SetJumpCount();
            collision.transform.parent = transform;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerManager.Instance.IsPlayerGround = false;
            collision.transform.parent = null;
        }
    }

}
