using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float startHealth = 100f;
    private float health = 0f;
    public Image healthBar;
    public bool alive = true;
    public int score;
    public AudioSource hit;
    public Renderer rend;
    public Collider col;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        alive = true;
        hit = GetComponent<AudioSource>();
       
    }

    public void TakeDamage(float amount)
    {
        hit.Play();

        if (!alive)
        {
            return;
        }

        
        health -= amount;
        

        if (health <= 0)
        {
            hit.Play();
            health = 0;
            alive = false;
            gameObject.SetActive(false);
            lumberPos.enemiesAlive -= 1;
            Debug.Log("enemies alive: " + lumberPos.enemiesAlive);
            Score.score += score;
            
            
        }
        healthBar.fillAmount = health / startHealth;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / startHealth;
    }
}
