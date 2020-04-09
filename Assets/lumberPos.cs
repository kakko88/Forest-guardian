using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lumberPos : MonoBehaviour
{
    private int numberOfEnemies = 0;
    public GameObject prefab;
    public float timeBetweenWaves = 60f;
    private float countdown = 3f;
    public Text WaveCountdown;

    void Start()
    {
        
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        WaveCountdown.text = Mathf.Round(countdown).ToString();
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
