using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_SHOP : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateUpgradeButton("Speed Upgrade", Upgrades.GetCost(Upgrades.ItemType.SpeedUpgrade), 0);
        CreateUpgradeButton("Beak Upgrade", Upgrades.GetCost(Upgrades.ItemType.BeakUpgrade), 1);
        CreateUpgradeButton("Pellet Gun Upgrade", Upgrades.GetCost(Upgrades.ItemType.PelletGun), 2);
    }
    private void CreateUpgradeButton(string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 80f;
        shopItemRectTransform.anchoredPosition = new Vector2(125, 150-shopItemHeight * positionIndex);

        shopItemTransform.Find("textName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("textCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());


    
    }
}
