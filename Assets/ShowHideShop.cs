using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideShop : MonoBehaviour
{
    public static bool showShop;
    public GameObject aim;
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
                aim.gameObject.SetActive(true);
            }
            else if (showShop == true)
            {
                aim.gameObject.SetActive(false);
                child.gameObject.SetActive(true);
                
            }
        }

    }
}
