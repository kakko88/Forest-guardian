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
    //public static bool showShop = true;

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
        CreateUpgradeButton(Upgrades.ItemType.SquirrelTree1, "Squirrel Tree1", Upgrades.GetCost(Upgrades.ItemType.SquirrelTree1), 2);
        CreateUpgradeButton(Upgrades.ItemType.SquirrelTree2, "Squirrel Tree2", Upgrades.GetCost(Upgrades.ItemType.SquirrelTree2), 3);
        CreateUpgradeButton(Upgrades.ItemType.SquirrelTree3, "Squirrel Tree3", Upgrades.GetCost(Upgrades.ItemType.SquirrelTree3), 4);
        CreateUpgradeButton(Upgrades.ItemType.SquirrelTree4, "Squirrel Tree4", Upgrades.GetCost(Upgrades.ItemType.SquirrelTree4), 5);
        CreateUpgradeButton(Upgrades.ItemType.SquirrelHome, "Squirrel HomeTree", Upgrades.GetCost(Upgrades.ItemType.SquirrelHome), 6);
    }
    public void Update()
    {
       /* if (showShop == true)
        {
            Show();
        }
        else if (showShop == false)
        {
            Hide();
        }*/
    }
    private void CreateUpgradeButton(Upgrades.ItemType itemType, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 80f;
        shopItemRectTransform.anchoredPosition = new Vector2(450, 50-shopItemHeight * positionIndex);

        shopItemTransform.Find("textName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("textCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());


        Button btn = shopItemRectTransform.GetComponent<Button>();
        btn.onClick.AddListener(() => TryBuyItem(itemType));

    }

    private void TryBuyItem(Upgrades.ItemType itemType)
    {
        Debug.Log("Clicked Button" + itemType);
        Upgrades.TrySpendMoney(itemType);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
