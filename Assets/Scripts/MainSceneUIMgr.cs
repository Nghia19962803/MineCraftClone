using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIMgr : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public GameObject confirmWatchAds;
    int amountCoin;

    [SerializeField] Button confirmWatchAdBtn;
    [SerializeField] Button watchAdBtn;

    [Header("CONTROLLER")]
    [SerializeField] Button AddBlock;
    [SerializeField] Button removeBlock;

    void Start()
    {
        confirmWatchAdBtn.onClick.AddListener(OnClickConfirmWatch);
        watchAdBtn.onClick.AddListener(OnClickReward);
        amountCoin = 0;

        AddBlock.onClick.AddListener(MainSceneMgr.Instance.AddBlock);
        removeBlock.onClick.AddListener(MainSceneMgr.Instance.RemoveBlock);
    }

    public void OnClickReward()
    {
        confirmWatchAds.SetActive(true);
    }

    public void OnClickConfirmWatch()
    {
        // watch ads
        MainSceneMgr.Instance.GetGoogleAdsManager().ShowRewardedAd();
    }
    
    public void OnUserEarnReward()
    {
        // earn reward
        amountCoin += 100;
        coinText.text = amountCoin.ToString();
        confirmWatchAds.SetActive(false);
        Debug.Log("amountCoin : " + amountCoin);
    }
}
