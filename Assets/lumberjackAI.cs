using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class lumberjackAI : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Animator animator;
    //public GameObject tree1;
    //public GameObject tree2;
    //public GameObject tree3;
    //public GameObject tree4;
    //public GameObject HomeTree;
    //public GameObject LumberJack;
    bool attack = false;


    

    void Start()
    {
        
        findTree();
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tree1 = GameObject.Find("tower tree (1)");
        GameObject tree2 = GameObject.Find("tower tree (2)");
        GameObject tree3 = GameObject.Find("tower tree (3)");
        GameObject tree4 = GameObject.Find("tower tree (4)");
        GameObject HomeTree = GameObject.Find("Home tree");

        

        
        if (Vector3.Distance(transform.position, tree1.transform.position) < 200f)
        {

            if (attack == false)
            {
                Attack();

                attack = true;
            }

            attack = false;
           
        }

        if (Vector3.Distance(transform.position, tree2.transform.position) < 200f)
        {
            if (attack == false)
            {
                Attack();

                attack = true;
            }

            attack = false;

        }
        
        if (Vector3.Distance(transform.position, tree3.transform.position) < 200f)
        {
            if (attack == false)
            {
                Attack();

                attack = true;
            }

            attack = false;

        }

        if (Vector3.Distance(transform.position, tree4.transform.position) < 200f)
        {
            if (attack == false)
            {
                Attack();

                attack = true;
            }

            attack = false;

        }

        if (Vector3.Distance(transform.position, HomeTree.transform.position) < 200f)
        {
           if (attack == false)
            {
                Attack();

                attack = true;
            }

            attack = false;
            
        }
        

    }


    public void findTree()
    {
        
        GameObject tree1 = GameObject.Find("tower tree (1)");
        GameObject tree2 = GameObject.Find("tower tree (2)");
        GameObject tree3 = GameObject.Find("tower tree (3)");
        GameObject tree4 = GameObject.Find("tower tree (4)");
        GameObject HomeTree = GameObject.Find("Home tree");
        GameObject maintree = new GameObject();

        

        float shortestDistance = Mathf.Min(Vector3.Distance(tree1.transform.position, transform.position),
            Vector3.Distance(tree2.transform.position, transform.position),
            Vector3.Distance(tree3.transform.position, transform.position), Vector3.Distance(tree4.transform.position, transform.position));


        if (shortestDistance == Mathf.Min(Vector3.Distance(tree1.transform.position, transform.position)))
        {
            maintree = tree1;
            
        }
        else if (shortestDistance == Mathf.Min(Vector3.Distance(tree2.transform.position, transform.position)))
        {
            maintree = tree2;
            
        }
        else if (shortestDistance == Mathf.Min(Vector3.Distance(tree3.transform.position, transform.position)))
        {
            maintree = tree3;

        }
        else if (shortestDistance == Mathf.Min(Vector3.Distance(tree4.transform.position, transform.position))) 
        {
            maintree = tree4;

        }
        else
        {
            maintree = HomeTree;
            
        }

       

        agent.SetDestination(maintree.transform.position);

    }

    void Attack()
    {
       
     animator.SetTrigger("Attack");
      
    }
}