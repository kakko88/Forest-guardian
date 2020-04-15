using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class lumberjackAI : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Animator animator;
    bool isPlaying = false;
    float time = 0f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask treeLayers;
    public LayerMask HomeLayer;
    public int attackDMG = 5;

    public Transform target = null;
    public string towerTag = "Tower";

    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject HomeTree;
    GameObject[] TowerTrees;



    void Start()
    {

        animator = GetComponent<Animator>();

        InvokeRepeating("findTree", 0f, 3f);

        tree1 = GameObject.Find("tower tree (1)");
        tree2 = GameObject.Find("tower tree (2)");
        tree3 = GameObject.Find("tower tree (3)");
        tree4 = GameObject.Find("tower tree (4)");
        HomeTree = GameObject.Find("Home tree");
        TowerTrees = new GameObject[4];
        TowerTrees[0] = tree1;
        TowerTrees[1] = tree2;
        TowerTrees[2] = tree3;
        TowerTrees[3] = tree4;

        //findTree();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
            Debug.Log("null target");

        }

        Vector3 tree1Pos = new Vector3(tree1.transform.position.x, transform.position.y, tree1.transform.position.z);
        Vector3 tree2Pos = new Vector3(tree2.transform.position.x, transform.position.y, tree2.transform.position.z);
        Vector3 tree3Pos = new Vector3(tree3.transform.position.x, transform.position.y, tree3.transform.position.z);
        Vector3 tree4Pos = new Vector3(tree4.transform.position.x, transform.position.y, tree4.transform.position.z);
        Vector3 HomeTreePos = new Vector3(HomeTree.transform.position.x, transform.position.y, HomeTree.transform.position.z);


        if (Vector3.Distance(transform.position, tree1.transform.position) < 200f && tree1.GetComponent<TowerHealth>().alive == true)
        {
            transform.LookAt(tree1Pos);
            animator.SetBool("isWalking", false);
            Attack();
            Debug.Log("tree1");
          
        }

        if (Vector3.Distance(transform.position, tree2.transform.position) < 200f && tree2.GetComponent<TowerHealth>().alive == true)
        {
            transform.LookAt(tree2Pos);
            animator.SetBool("isWalking", false);
            Attack();
            Debug.Log("tree2");

        }
        
        if (Vector3.Distance(transform.position, tree3.transform.position) < 200f && tree3.GetComponent<TowerHealth>().alive == true)
        {
            transform.LookAt(tree3Pos);
            animator.SetBool("isWalking", false);
            Attack();
            Debug.Log("tree3");

        }

        if (Vector3.Distance(transform.position, tree4.transform.position) < 200f && tree4.GetComponent<TowerHealth>().alive == true)
        {
            transform.LookAt(tree4Pos);
            animator.SetBool("isWalking", false);
            Attack();
            Debug.Log("tree4");

        }

        if (Vector3.Distance(transform.position, HomeTree.transform.position) < 250f && HomeTree.GetComponent<TowerHealth>().alive == true)
        {
            transform.LookAt(HomeTreePos);
            animator.SetBool("isWalking", false);
            Attack();
            Debug.Log("homeTree");

        }


      
    }

    
    public void findTree()
    {
        
      
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTower = null;

        foreach (GameObject tower in TowerTrees)
        {
            float distanceToTower = Vector3.Distance(transform.position, tower.transform.position);

            if (tower.GetComponent<TowerHealth>().alive == true)
            {
                if (distanceToTower < shortestDistance)
                {
                    shortestDistance = distanceToTower;
                    nearestTower = tower;

                }

            }
            
           

        }

        if (tree1.GetComponent<TowerHealth>().alive == false && tree2.GetComponent<TowerHealth>().alive == false && tree3.GetComponent<TowerHealth>().alive == false && tree4.GetComponent<TowerHealth>().alive == false && HomeTree.GetComponent<TowerHealth>().alive == true)
        {
            float distanceToHome = Vector3.Distance(transform.position, HomeTree.transform.position);
            if (distanceToHome < shortestDistance)
            {
                shortestDistance = distanceToHome;
                nearestTower = HomeTree;

            }

        }

        if (nearestTower != null)
        {
            target = nearestTower.transform;
            
        }
        else
        {
            target = null;
        }

        agent.SetDestination(target.transform.position);
        animator.SetBool("isWalking", true);

    }


    void Attack()
    {
        if (isPlaying == false)
        {
            animator.SetTrigger("Attack");

            Collider[] hitTrees = Physics.OverlapSphere(attackPoint.position, attackRange, treeLayers);

            foreach (Collider tree in hitTrees)
            {
                if (tree.GetComponent<TowerHealth>().alive == true)
                {
                    tree.GetComponent<TowerHealth>().TakeDamage(attackDMG);
                }
                
            }

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

        
    }

     void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;

        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}