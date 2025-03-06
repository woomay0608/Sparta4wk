using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int PlayerHealth;
    public int curhealth;
    public int JumpCount;
    public int curJumpCount;

    private void Start()
    {
        curhealth = PlayerHealth;
        curJumpCount = JumpCount;
    }

    public void SetJumpCount()
    {
        curJumpCount = JumpCount;
    }
}
