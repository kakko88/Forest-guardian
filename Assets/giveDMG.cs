﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveDMG : MonoBehaviour
{
    float damage = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
    }

}
