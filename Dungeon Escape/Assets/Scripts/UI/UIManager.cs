using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager UIinstance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Error: UI Manager is NULL");
            }

            return instance;
        }
    }

    [SerializeField] Text playerGemCount = default;
    [SerializeField] Image selectionImage = default;

    private void Awake()
    {
        int numSessions = FindObjectsOfType<UIManager>().Length;

        if (numSessions > 1)
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

    public void OpenShop(int g)
    {
        playerGemCount.text = " " + g.ToString() + "G";
    }



}
