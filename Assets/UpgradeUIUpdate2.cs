using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeUIUpdate2 : MonoBehaviour
{
    private TextMeshProUGUI beak;
    void Start()
    {
        beak = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        beak.text = Upgrades.beakUpgradeLvl.ToString();
    }
}
