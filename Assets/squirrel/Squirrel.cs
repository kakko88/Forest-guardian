using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    public static Transform target;
    public float range = 15f;
    public Transform attackPoint;
    public string enemyTag = "Enemy";
    public float rotationSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Animator animator;
    private bool isPlaying = false;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null; 

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }

        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;

        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;

        }

        // target lock on
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

      
            if(isPlaying == false)
            {
            Debug.Log("animate");
                animator.SetTrigger("Shoot");
              //Shoot();
              //fireCountDown = 1f / fireRate;

                isPlaying = true;
            }

            if (isPlaying == true)
            {
                time = time + Time.deltaTime;

                if (time > 2.20f)
                {
                    isPlaying = false;

                    time = 0f;

                }
            }

       

        //fireCountDown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        GameObject bulletGO =  (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);

        }
            
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, range); 
    }
}
