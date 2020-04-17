using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopSound : MonoBehaviour
{
    public AudioClip chop;
    public AudioSource audioS;
    public GameObject impactEffect;
    public float x = 0;
    public float y = 0;
    public float z = 0;
    
    void Chop()
    {
        audioS.PlayOneShot(chop);
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position + new Vector3(x, y, z), transform.rotation);
        Destroy(effectIns, 2f);
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
