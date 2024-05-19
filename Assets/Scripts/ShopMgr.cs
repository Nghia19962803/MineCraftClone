using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

public class ShopMgr : MonoBehaviour
{
    [SerializeField] string coin50;
    [SerializeField] string removeAds;

    [SerializeField] List<GameObject> boothsList;
    [SerializeField] Button openShopBtn;
    private bool isShopOpen;
    public void Init()
    {
        foreach (GameObject go in boothsList)
        {
            go.SetActive(false);
        }
        isShopOpen = false;
        openShopBtn.onClick.AddListener(OpenCloseShop);
    }
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == coin50)
        {
            Debug.Log("add 50 coins");
        }
        else if (product.definition.id == removeAds)
        {
            Debug.Log("remove ads");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription reason)
    {
        Debug.Log("your purchase is fail" + reason);
    }

    public void OpenCloseShop()
    {
        isShopOpen = !isShopOpen;
        foreach (GameObject go in boothsList)
        {
            go.SetActive(isShopOpen);
        }
    }
}
