using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeUIUpdate : MonoBehaviour
{
    private TextMeshProUGUI spd; 
    void Start()
    {
        spd = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        spd.text = Upgrades.speedUpgradeLvl.ToString();   
    }
}
