using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static PlayerManager instance;
    public static PlayerManager Instance { get { return instance; } set { instance = value; } }



    private Player _player;
    public Player Player { get { return _player; }    }

    private PlayerUI playerUI;
    public PlayerUI PlayerUI { get { return playerUI; }  }

    private PlayerController playerController;
    public PlayerController PlayerController { get { return playerController; } }

    public bool IsPlayerGround = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _player = FindAnyObjectByType<Player>();
        playerUI = FindAnyObjectByType<PlayerUI>();
        playerController = FindAnyObjectByType<PlayerController>();
    }
}
