using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMgr : MonoBehaviour
{
    public static MainSceneMgr Instance;

    [SerializeField] private ModifyTerrain mTerrain;
    public ModifyTerrain GetModifyTerain() => mTerrain;

    private void Awake()
    {
        Instance = this;
    }

    public void AddBlock()
    {

    }

    public void RemoveBlock()
    {

    }
}
