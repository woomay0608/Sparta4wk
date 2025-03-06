using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static PlayerManager instance;
    public static PlayerManager Instance { get { return instance; } set { instance = value; } }

    public Player _player;

    public Player Player { get { return _player; } set { _player = value; } }


    public bool IsPlayerGround = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
