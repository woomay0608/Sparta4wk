using UnityEngine;
using UnityEngine.AI;

public class Destination : MonoBehaviour
{
    private AI AI;


    private void Start()
    {
        AI = transform.parent.transform.GetChild(1).GetComponent<AI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("AI"))
        {
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            //에이전트가 목적지에 닿으면 시작위치로 되돌리고 메인 카메라를 킴
            other.transform.position = AI.GetStartPosition();
            AI.MainCameraOn();
            PlayerManager.Instance.PlayerController.gameObject.SetActive(true);
        }
    }

}
