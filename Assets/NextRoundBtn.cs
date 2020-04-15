using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextRoundBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(() => BeginNextRound());

    }
    public void BeginNextRound()
    {
        lumberPos.startNextRound = true; 
    }
}
