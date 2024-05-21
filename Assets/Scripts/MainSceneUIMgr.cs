using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIMgr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] GameObject confirmWatchAds;
    [SerializeField] Joystick fixJoy;
    [SerializeField] Button buildBtn;
    [SerializeField] Button brokeBtn;
    int amountCoin;

    [SerializeField] Button confirmWatchAdBtn;
    [SerializeField] Button watchAdBtn;

    [Header("CONTROLLER")]
    [SerializeField] Button AddBlock;
    [SerializeField] Button removeBlock;

    [Header("TEXTURE SELECT")]
    [SerializeField] Button rockBtn;
    [SerializeField] Button grassBtn;
    [SerializeField] Button iceBtn;

    public Vector3 moveInput
    {
        get { return new Vector3(fixJoy.Horizontal, 0, fixJoy.Vertical); }
    }

    public void Init()
    {
        confirmWatchAdBtn.onClick.AddListener(OnClickConfirmWatch);
        watchAdBtn.onClick.AddListener(OnClickReward);
        amountCoin = 0;

        AddBlock.onClick.AddListener(MainSceneMgr.Instance.AddBlock);
        removeBlock.onClick.AddListener(MainSceneMgr.Instance.RemoveBlock);

        AddChangeTextureEventBtn();
        AddBuildEventBtn();
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

    void AddChangeTextureEventBtn()
    {
        rockBtn.onClick.AddListener(() =>
        {
            MainSceneMgr.Instance.GetModifyTerain().SetTexture(textureType.rock);
        });

        grassBtn.onClick.AddListener(() =>
        {
            MainSceneMgr.Instance.GetModifyTerain().SetTexture(textureType.grass);
        });

        iceBtn.onClick.AddListener(() =>
        {
            MainSceneMgr.Instance.GetModifyTerain().SetTexture(textureType.ice);
        });
    }

    void AddBuildEventBtn()
    {
        buildBtn.onClick.AddListener(() =>
        {
            MainSceneMgr.Instance.AddBlock();
        });

        brokeBtn.onClick.AddListener(() =>
        {
            MainSceneMgr.Instance.RemoveBlock();
        });
    }
}
