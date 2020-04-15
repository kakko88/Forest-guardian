﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{
    public Text WavesText;

    void OnEnable()
    {
        WavesText.text = PlayerStats.Waves.ToString();
    }
     
    public void Menu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
