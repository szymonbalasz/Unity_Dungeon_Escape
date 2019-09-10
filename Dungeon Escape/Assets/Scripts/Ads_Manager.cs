using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ads_Manager : MonoBehaviour
{
    public void ShowRewardedAd()
    {
        //this is where we'd normally show an ad
        GameManager.GMinstance.Player.AddGems(100);
        UIManager.UIinstance.OpenShop(GameManager.GMinstance.Player.GetGems());
    }
}
