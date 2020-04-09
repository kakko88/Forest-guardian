using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public float startHealth = 100f;
    private float health = 0f;
    public Image healthBar;
    public bool alive = true;
    public Renderer rend;
    public Collider col;
    



    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        alive = true;
        rend = GetComponent<Renderer>();
        col = GetComponent<MeshCollider>();
       
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
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            rend.enabled = false;
            col.enabled = false;
           

            return;
        }
        health -= amount;

        healthBar.fillAmount = health / startHealth;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
