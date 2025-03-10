using TMPro;
using UnityEngine;

public class InteractiveText : MonoBehaviour
{
   
    [SerializeField]
    private TextMeshPro txtCommand;
    void Start()
    {
        txtCommand = transform.GetChild(1).GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        Moving();
    }
    private void Moving()
    {
        //플레이어 - 텍스트로 플레이어를 바라보는 방향을 구함
        Vector2 Dir = new Vector2(PlayerManager.Instance.Player.transform.position.x, PlayerManager.Instance.Player.transform.position.z)
    - new Vector2(transform.parent.position.x, transform.parent.position.z);
        //라디안으로 변환
        float angle = Mathf.Atan2(Dir.y, Dir.x);
        float x = 1f * Mathf.Cos(angle);
        float y = 1f * Mathf.Sin(angle);
        //원으로 돌도록 만듬
        transform.position = new Vector3(transform.parent.position.x + x, PlayerManager.Instance.Player.transform.position.y+1.5f, transform.parent.position.z + y);
        transform.eulerAngles = new Vector3(0f, PlayerManager.Instance.Player.transform.eulerAngles.y - 180f, 0f);
    }

    public void SetCommandText(string Text)
    {
        txtCommand.text = Text;
    }

  
  
}
