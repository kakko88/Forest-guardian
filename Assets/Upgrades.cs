using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades
{
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
}