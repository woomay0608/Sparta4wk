using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Destination : MonoBehaviour
{
    public AI AI;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("AI"))
        {
            collision.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            collision.transform.position = AI.StartPo();
            AI.CameraOn();
            PlayerManager.Instance.PlayerController.gameObject.SetActive(true);
        }
    }

}
