using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveText : MonoBehaviour
{
    private Sprite Back;
    private TextMesh TextMesh;
    void Start()
    {
        Back = transform.GetChild(0).GetComponent<Sprite>();
        TextMesh = transform.GetChild(1).GetComponent<TextMesh>();
    }

    private void Update()
    {
        Vector2 Dir = new Vector2(PlayerManager.Instance.Player.transform.position.x, PlayerManager.Instance.Player.transform.position.z)
        - new Vector2(transform.parent.position.x, transform.parent.position.z);
            
        
        float angle = Mathf.Atan2(Dir.y, Dir.x);
        float x =  1f * Mathf.Cos(angle);
        float y = 1f * Mathf.Sin(angle);

        Debug.Log(x);
        Debug.Log(y);
        transform.position =  new Vector3(transform.parent.position.x +x, transform.position.y, transform.parent.position.z+ y);
        transform.eulerAngles = new Vector3(0f, PlayerManager.Instance.Player.transform.eulerAngles.y - 180f, 0f);
    }

    public void StartPosition()
    {
        
    }
  
  
}
