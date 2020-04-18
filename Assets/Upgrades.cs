using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades
{
    private static GameObject squirrel;
    public BuildManager buildManager;
    public static GameObject nodes;
    private static int nodeCount = 0;
    private static int nodeCount2 = 4;
    private static int nodeCount3 = 8;
    private static int nodeCount4 = 12;
    private static int nodeCount5 = 16;
    public static GameObject maxed;
    

    void Start()
    {
        maxed.SetActive(false);
        maxed = GameObject.Find("Maxed");
    }

    public enum ItemType
    {
        SpeedUpgrade,
        BeakUpgrade,
        PelletGun,
        SquirrelTree1,
        SquirrelTree2,
        SquirrelTree3,
        SquirrelTree4,
        SquirrelHome,


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
        nodes = GameObject.Find("Nodes");
        Transform[] NodeList = new Transform[nodes.transform.childCount];
        for (int i = 0; i < nodes.transform.childCount; i++)
        {
            NodeList[i] = nodes.transform.GetChild(i);
        }

        switch (itemType)
        {
            default:
            case ItemType.SpeedUpgrade: MFlight.Demo.PlaneControls.maxSpeed += 50;
                return;
            case ItemType.BeakUpgrade: MFlight.Demo.PlaneControls.damageModifier += 10;
                return;
            case ItemType.SquirrelTree1:
                {

                    if (nodeCount <= 3)
                    {
                        GameObject squirrelToBuild = BuildManager.instance.GetSquirrelToBuild();
                        squirrel = GameObject.Instantiate(squirrelToBuild, NodeList[nodeCount].transform.position, NodeList[nodeCount].transform.rotation);
                        nodeCount += 1;
                        

                    }
                    return;
                }
            case ItemType.SquirrelTree2:
                {
                    if (nodeCount2 <= 7)
                    {
                        GameObject squirrelToBuild = BuildManager.instance.GetSquirrelToBuild();
                        squirrel = GameObject.Instantiate(squirrelToBuild, NodeList[nodeCount2].transform.position, NodeList[nodeCount2].transform.rotation);
                        nodeCount2 += 1;
                       
                    }
                    return;
                }
            case ItemType.SquirrelTree3:
                {
                    if (nodeCount3 <= 11)
                    {
                        GameObject squirrelToBuild = BuildManager.instance.GetSquirrelToBuild();
                        squirrel = GameObject.Instantiate(squirrelToBuild, NodeList[nodeCount3].transform.position, NodeList[nodeCount3].transform.rotation);
                        nodeCount3 += 1;
                        
                    }
                    return;
                }
            case ItemType.SquirrelTree4:
                {
                    if (nodeCount4 <= 15)
                    {
                        GameObject squirrelToBuild = BuildManager.instance.GetSquirrelToBuild();
                        squirrel = GameObject.Instantiate(squirrelToBuild, NodeList[nodeCount4].transform.position, NodeList[nodeCount4].transform.rotation);
                        nodeCount4 += 1;

                    }
                    return;
                }
            case ItemType.SquirrelHome:
                {
                    if (nodeCount5 <= 19)
                    {
                        GameObject squirrelToBuild = BuildManager.instance.GetSquirrelToBuild();
                        squirrel = GameObject.Instantiate(squirrelToBuild, NodeList[nodeCount5].transform.position, NodeList[nodeCount5].transform.rotation);
                        nodeCount5 += 1;

                    }
                    return;
                }

        }

    }

    IEnumerator WaitForSec()
    {
        
        yield return new WaitForSeconds(3);
        
    }

   

    public static int GetCost(ItemType itemType)
    {
        

        switch (itemType)
        {

        default:
            case ItemType.SpeedUpgrade: return 50;
            case ItemType.BeakUpgrade: return 30;
            case ItemType.PelletGun: return 100;
            case ItemType.SquirrelTree1:
                {
                    if (nodeCount <= 3)
                    {
                        return 200;
                    }
                    else
                    {
                        maxed.SetActive(true);
                        
                        
                        Debug.Log("Maxed out");
                        
                    }
                    return 0;
                }
            case ItemType.SquirrelTree2:
                {
                    if (nodeCount <= 7)
                    {
                        return 200;
                    }
                    else
                    {
                        Debug.Log("Maxed out");
                    }
                    return 0;
                }
            case ItemType.SquirrelTree3:
                {
                    if (nodeCount <= 11)
                    {
                        return 200;
                    }
                    else
                    {
                        Debug.Log("Maxed out");
                    }
                    return 0;
                }
            case ItemType.SquirrelTree4:
                {
                    if (nodeCount <= 15)
                    {
                        return 200;
                    }
                    else
                    {
                        Debug.Log("Maxed out");
                    }
                    return 0;
                }
            case ItemType.SquirrelHome:
                {
                    if (nodeCount <= 19)
                    {
                        return 200;
                    }
                    else
                    {
                        Debug.Log("Maxed out");
                    }
                    return 0;
                }
        }
    }

 
}