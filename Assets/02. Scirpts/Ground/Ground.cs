using UnityEngine;

public class Ground : MonoBehaviour
{

    public bool IsBake = false;
    public AI ai;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") || collision.collider.CompareTag("AI"))
        {
            //�ٴڿ� ������ ���� Ƚ�� �ʱ�ȭ 
            PlayerManager.Instance.IsPlayerGround = true;
            PlayerManager.Instance.Player.SetJumpCount();
            //�θ�� �����ؼ� �÷��̾�� ���� �����̰� �ϱ�
            collision.transform.parent = transform;
        }

    }
    ///////////////Ư�� ��Ͽ��� ���� ����ŷ ���� �Լ�/////////////////////
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
