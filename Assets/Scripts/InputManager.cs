using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] Joystick fixJoy;
    [SerializeField] Button buildBtn;
    [SerializeField] Button brokeBtn;

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
        buildBtn.onClick.AddListener(() =>
        {
            MainSceneMgr.Instance.AddBlock();
        });

        brokeBtn.onClick.AddListener(() =>
        {
            MainSceneMgr.Instance.RemoveBlock();
        });
    }

    void Update()
    {
        
    }
}
