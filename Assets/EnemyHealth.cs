﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnemyHealth : MonoBehaviour
{
    public float startHealth = 100f;
    private float health = 0f;
    public Image healthBar;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        alive = true;
    }

    public void TakeDamage(float amount)
    {
        if (!alive)
        {
            return;
        }

        if (health <= 0)
        {
            health = 0;
            alive = false;
            gameObject.SetActive(false);
            Score.score += 10;
        }
        health -= amount;

        healthBar.fillAmount = health / startHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
