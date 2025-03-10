using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractiveText : MonoBehaviour
{
    [SerializeField]
    private Sprite Back;
    [SerializeField]
    private TextMeshPro TextMesh;
    void Start()
    {
        Back = transform.GetChild(0).GetComponent<Sprite>();
        TextMesh = transform.GetChild(1).GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        Moving();
    }
    private void Moving()
    {
        Vector2 Dir = new Vector2(PlayerManager.Instance.Player.transform.position.x, PlayerManager.Instance.Player.transform.position.z)
    - new Vector2(transform.parent.position.x, transform.parent.position.z);
        float angle = Mathf.Atan2(Dir.y, Dir.x);
        float x = 1f * Mathf.Cos(angle);
        float y = 1f * Mathf.Sin(angle);
        transform.position = new Vector3(transform.parent.position.x + x, PlayerManager.Instance.Player.transform.position.y+1.5f, transform.parent.position.z + y);
        transform.eulerAngles = new Vector3(0f, PlayerManager.Instance.Player.transform.eulerAngles.y - 180f, 0f);
    }

    public void SetText(string Text)
    {
        TextMesh.text = Text;
    }

  
  
}
