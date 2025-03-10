using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static PlayerManager instance;
    public static PlayerManager Instance { get { return instance; } set { instance = value; } }



    private Player player;
    public Player Player { get { return player; }    }

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

        player = FindAnyObjectByType<Player>();
        playerUI = FindAnyObjectByType<PlayerUI>();
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        if(Player.transform.position.y < -20)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Player.Curhealth = 3;
        Player.transform.position = new Vector3(0f,0f, 0f);

    }
}
