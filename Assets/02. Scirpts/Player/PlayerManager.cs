using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static PlayerManager instance;
    public static PlayerManager Instance { get { return instance; } set { instance = value; } }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
