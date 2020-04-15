using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveCount : MonoBehaviour
{
    public Text WavesText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WavesText.text = PlayerStats.Waves.ToString();
    }
}
