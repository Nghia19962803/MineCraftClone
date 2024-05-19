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


    public ModifyTerrain GetModifyTerain() => mTerrain;
    public InputManager GetInputManager() => inputMgr;
    public World GetWorldManager() => worldMgr;
    public GoogleAdsMgr GetGoogleAdsManager() => adsMgr;

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
    }
    public void AddBlock()
    {

    }

    public void RemoveBlock()
    {

    }
}
