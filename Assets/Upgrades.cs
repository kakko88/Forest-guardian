using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades
{
    public static int speedUpgradeLvl, beakUpgradeLvl;
    public static TextMeshProUGUI textMeshSpd;
    public TextMeshProUGUI textMeshBeak;
    public enum ItemType
    {
        SpeedUpgrade,
        BeakUpgrade,
        PelletGun,


    }


public static void TrySpendMoney(ItemType itemType)
    {
        if (Score.score >= GetCost(itemType))
        {
            Score.score -= GetCost(itemType);
            buyUpgrade(itemType);
            SetUpgradeLevel(itemType);
            

        }
    }
public static void buyUpgrade(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.SpeedUpgrade: MFlight.Demo.PlaneControls.maxSpeed += 50;
                return;
            case ItemType.BeakUpgrade: MFlight.Demo.PlaneControls.damageModifier += 10;
                return;

        }

    }

public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.SpeedUpgrade: return 50;
            case ItemType.BeakUpgrade: return 30;
            case ItemType.PelletGun: return 100;
        }
    }
public static void SetUpgradeLevel(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.SpeedUpgrade: speedUpgradeLvl += 1;
                return;
            case ItemType.BeakUpgrade: beakUpgradeLvl += 1;
                return;
        }

    }
}