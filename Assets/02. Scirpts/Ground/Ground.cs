using UnityEngine;

public class Ground : MonoBehaviour
{

    public bool IsBake = false;
    public AI AI;
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

    private void OnCollisionStay(Collision collision)
    {
        if (IsBake)
        {
            //�߰��������� � ������ �ٽ� ������Ʈ�� �ٴ� �� �ִ� ǥ���� �����ϵ��� ��
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
