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
    [SerializeField] Text gemCountText = default;
    [SerializeField] GameObject[] lifeBarArray = default;

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

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCountText(int g)
    {
        gemCountText.text = " " + g;
    }

    public void UpdateLives(int livesRemaining)
    {
        if (livesRemaining >= 0)
        {
            lifeBarArray[livesRemaining].SetActive(false);
        }
    }
}
