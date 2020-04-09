using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject HomeTree;
    public GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
        HomeTree = GameObject.Find("Home tree");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;  

        if (HomeTree.GetComponent<TowerHealth>().alive == false)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        GameOverUI.SetActive(true); 
    }
}

