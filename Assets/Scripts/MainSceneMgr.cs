using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMgr : MonoBehaviour
{
    public static MainSceneMgr Instance;

    [SerializeField] private ModifyTerrain mTerrain;
    [SerializeField] private InputManager inputMgr;
    [SerializeField] private World worldMgr;
    [SerializeField] private GoogleAdsMgr adsMgr;
    [SerializeField] private MainSceneUIMgr uiMgr;
    [SerializeField] private ShopMgr shopMgr;

    public ModifyTerrain GetModifyTerain() => mTerrain;
    public InputManager GetInputManager() => inputMgr;
    public World GetWorldManager() => worldMgr;
    public GoogleAdsMgr GetGoogleAdsManager() => adsMgr;
    public MainSceneUIMgr GetUIManager() => uiMgr;
    public ShopMgr GetShopMgr() => shopMgr;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        mTerrain.Init();
        inputMgr.Init();
        worldMgr.Init();
        adsMgr.Init();
        shopMgr.Init();
    }
    public void AddBlock()
    {
        mTerrain.AddBlock();
    }

    public void RemoveBlock()
    {
        mTerrain.RemoveBlock();
    }
}
