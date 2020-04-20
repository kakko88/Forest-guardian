using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlap : MonoBehaviour
{
    public AudioClip flap;
    public AudioSource audioS;
    

    void Flap()
    {
        audioS.PlayOneShot(flap);
        
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
