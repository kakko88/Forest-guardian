using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideShop : MonoBehaviour
{
    public static bool showShop;
    void Start()
    {
        
    }
    void Update()
    {
        foreach (Transform child in this.transform)
        {
            if (showShop == false)
            {
                child.gameObject.SetActive(false);
            }
            else if (showShop == true)
            {
                child.gameObject.SetActive(true);
            }
        }

    }
}
