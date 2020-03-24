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
