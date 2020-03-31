using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_SHOP : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateUpgradeButton(Upgrades.ItemType.SpeedUpgrade, "Speed Upgrade", Upgrades.GetCost(Upgrades.ItemType.SpeedUpgrade), 0);
        CreateUpgradeButton(Upgrades.ItemType.BeakUpgrade, "Beak Upgrade", Upgrades.GetCost(Upgrades.ItemType.BeakUpgrade), 1);
        CreateUpgradeButton(Upgrades.ItemType.PelletGun, "Pellet Gun Upgrade", Upgrades.GetCost(Upgrades.ItemType.PelletGun), 2);
    }
    private void CreateUpgradeButton(Upgrades.ItemType itemType, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 80f;
        shopItemRectTransform.anchoredPosition = new Vector2(125, 250-shopItemHeight * positionIndex);

        shopItemTransform.Find("textName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("textCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());


        Button btn = shopItemRectTransform.GetComponent<Button>();
        btn.onClick.AddListener(() => TryBuyItem(itemType));

        void TryBuyItem(Upgrades.ItemType newitemType)
        {
            shopCustomer.BoughtItem(itemType);
            Debug.Log("Clicked Button");
        }

    
    }
}
