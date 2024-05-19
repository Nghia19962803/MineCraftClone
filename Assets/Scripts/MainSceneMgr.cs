using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMgr : MonoBehaviour
{
    public static MainSceneMgr Instance;

    [SerializeField] private ModifyTerrain mTerrain;
    public ModifyTerrain GetModifyTerain() => mTerrain;

    [SerializeField] private InputManager inputMgr;
    public InputManager GetInputManager() => inputMgr;

    [SerializeField] private World worldMgr;
    public World GetWorldManager() => worldMgr;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        mTerrain.Init();
        inputMgr.Init();
        worldMgr.Init();
    }
    public void AddBlock()
    {

    }

    public void RemoveBlock()
    {

    }
}
