using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this; 
    }

    public GameObject squirrelPrefab;

    private GameObject squirrelToBuild;

    public GameObject GetSquirrelToBuild()
    {
        return squirrelToBuild;
    }
    // Start is called before the first frame update
    void Start()
    {
        squirrelToBuild = squirrelPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
