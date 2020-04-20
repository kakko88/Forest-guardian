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

    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject HomeTree;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);

        tree1 = GameObject.Find("tower tree (1)");
        tree2 = GameObject.Find("tower tree (2)");
        tree3 = GameObject.Find("tower tree (3)");
        tree4 = GameObject.Find("tower tree (4)");
        HomeTree = GameObject.Find("Home tree");


    }

    void UpdateTarget()
    {
        Vector3 tree1Pos = new Vector3(tree1.transform.position.x, transform.position.y, tree1.transform.position.z);
        Vector3 tree2Pos = new Vector3(tree2.transform.position.x, transform.position.y, tree2.transform.position.z);
        Vector3 tree3Pos = new Vector3(tree3.transform.position.x, transform.position.y, tree3.transform.position.z);
        Vector3 tree4Pos = new Vector3(tree4.transform.position.x, transform.position.y, tree4.transform.position.z);
        Vector3 HomeTreePos = new Vector3(HomeTree.transform.position.x, transform.position.y, HomeTree.transform.position.z);

        if (Vector3.Distance(transform.position, tree1.transform.position) < 200f && tree1.GetComponent<TowerHealth>().alive == false)
        {
            Destroy(gameObject);

        }

        if (Vector3.Distance(transform.position, tree2.transform.position) < 200f && tree2.GetComponent<TowerHealth>().alive == false)
        {
            Destroy(gameObject);

        }

        if (Vector3.Distance(transform.position, tree3.transform.position) < 200f && tree3.GetComponent<TowerHealth>().alive == false)
        {
            Destroy(gameObject);

        }

        if (Vector3.Distance(transform.position, tree4.transform.position) < 200f && tree4.GetComponent<TowerHealth>().alive == false)
        {
            Destroy(gameObject);

        }

        if (Vector3.Distance(transform.position, HomeTree.transform.position) < 250f && HomeTree.GetComponent<TowerHealth>().alive == false)
        {
            Destroy(gameObject);

        }

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
