using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager GMinstance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("GameManager is null");
            }
            return instance;
        }
    }

    [SerializeField] private bool hasKeyToCastle;
    public bool HasKeyToCastle
    {
        get { return hasKeyToCastle; }
        set { hasKeyToCastle = value; }
    }

    public Player Player { get; private set; }

    private void Awake()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length;

        if (numGameManagers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    private void Start()
    {
        Player = FindObjectOfType<Player>();
    }
}
