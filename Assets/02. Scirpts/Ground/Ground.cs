using UnityEngine;

public class Ground : MonoBehaviour
{

    public bool IsBake = false;
    public AI AI;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") || collision.collider.CompareTag("AI"))
        {
            //바닥에 닿으면 점프 횟수 초기화 
            PlayerManager.Instance.IsPlayerGround = true;
            PlayerManager.Instance.Player.SetJumpCount();
            //부모로 설정해서 플레이어랑 같이 움직이게 하기
            collision.transform.parent = transform;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (IsBake)
        {
            //추가설정으로 어떤 땅에는 다시 에이전트가 다닐 수 있는 표면을 설정하도록 함
            AI.AISurfaceBake();
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
