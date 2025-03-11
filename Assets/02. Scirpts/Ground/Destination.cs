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
            //������Ʈ�� �������� ������ ������ġ�� �ǵ����� ���� ī�޶� Ŵ
            other.transform.position = AI.GetStartPosition();
            AI.MainCameraOn();
            PlayerManager.Instance.PlayerController.gameObject.SetActive(true);
        }
    }

}
