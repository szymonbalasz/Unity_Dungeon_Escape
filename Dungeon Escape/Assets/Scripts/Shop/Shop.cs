using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopPanel = default;
    private int currentlySelectedItem = 0;
    private int currentItemCost = 200;

    private Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponent<Player>();
            if (player != null)
            {
                UIManager.UIinstance.OpenShop(player.GetGems());
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }



    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0:
                UIManager.UIinstance.UpdateShopSelection(80);
                currentlySelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.UIinstance.UpdateShopSelection(-23);
                currentlySelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.UIinstance.UpdateShopSelection(-136);
                currentlySelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void buyItem()
    {
        if (player.GetGems() >= currentItemCost)
        {
            player.AddGems(currentItemCost * -1);
            shopPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(false);
        }
    }
}
