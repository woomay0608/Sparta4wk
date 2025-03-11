using UnityEngine;

public class Ground : MonoBehaviour
{

    public bool IsBake = false;
    public AI ai;
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
    ///////////////특정 블록에만 동적 베이킹 실행 함수/////////////////////
    private void OnCollisionStay(Collision collision)
    {
        if (IsBake && collision.gameObject.CompareTag("AI"))
        {
            ai.AISurfaceBake();
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
