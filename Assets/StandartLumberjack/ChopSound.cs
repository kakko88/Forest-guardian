using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopSound : MonoBehaviour
{
    public AudioClip chop;
    public AudioSource audioS;
    
    void Chop()
    {
        audioS.PlayOneShot(chop);
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
