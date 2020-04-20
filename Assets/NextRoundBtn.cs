using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextRoundBtn : MonoBehaviour
{
    public GameObject birdObject;
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
        birdObject = GameObject.Find("bird");
        birdObject.transform.position = new Vector3(-7.18f, 514.5f, -5.68f);
        lumberPos.startNextRound = true;


    }
}
