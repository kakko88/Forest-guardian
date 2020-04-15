using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lumberPos : MonoBehaviour
{
    private int numberOfEnemies = 0;
    public GameObject prefab;
    //private float timeBetweenWaves = 10f;
    private float countdownShop = 5f;
    public GameObject fastPrefab;
    public GameObject bossPrefab;
    public float timeBetweenWaves = 60f;
    private float countdown = 3f;
    public Text WaveCountdown;

    public static bool startNextRound;

    void Start()
    {
        //shop = GameObject.Find("Canvas/UI_SHOP");
    }



    void Update()
    {
        if (countdown <= 0f)
        {
            ShowHideShop.showShop = true;
            Debug.Log("SHOW TRUE2");
            if (startNextRound == true)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                ShowHideShop.showShop = false;
                Debug.Log("SHOW FALSE");
                startNextRound = false;
            }

        }
        if (countdown > 0f)
        {
            countdown -= Time.deltaTime;
            WaveCountdown.text = Mathf.Round(countdown).ToString();
            if (countdown <= 0f)
            {
               // UI_SHOP.showShop = true;
                Debug.Log("SHOW TRUE1");
            }
        }


    }

    IEnumerator SpawnWave()
    {
        numberOfEnemies++;
        PlayerStats.Waves++;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(10f);
        }


    }

    void SpawnFastEnemy()
    {
        Vector3 center = transform.position;
        Vector3 pos = RandomCircle(center, 1200.0f);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        Instantiate(fastPrefab, pos, rot);
    }

    void SpawnBossEnemy()
    {
        Vector3 center = transform.position;
        Vector3 pos = RandomCircle(center, 1200.0f);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        Instantiate(bossPrefab, pos, rot);
    }

    void SpawnEnemy()
    {
        Vector3 center = transform.position;
        Vector3 pos = RandomCircle(center, 1200.0f);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        Instantiate(prefab, pos, rot);

    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
