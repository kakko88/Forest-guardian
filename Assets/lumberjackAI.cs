using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class lumberjackAI : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Animator animator;

    
    void Start()
    {
        
        findTree();
        
    }

    // Update is called once per frame
    void Update()
    {

        
     
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
            
            if (Vector3.Distance(maintree.transform.position, transform.position) < 10f)
            {
                Attack();
            }
        }
        else if (shortestDistance == Mathf.Min(Vector3.Distance(tree2.transform.position, transform.position)))
        {
            maintree = tree2;

            if (Vector3.Distance(maintree.transform.position, transform.position) < 10f)
            {
                Attack();
            }
        }
        else if (shortestDistance == Mathf.Min(Vector3.Distance(tree3.transform.position, transform.position)))
        {
            maintree = tree3;

            if (Vector3.Distance(maintree.transform.position, transform.position) < 10f)
            {
                Attack();
            }
        }
        else if (shortestDistance == Mathf.Min(Vector3.Distance(tree4.transform.position, transform.position))) 
        {
            maintree = tree4;

            if (Vector3.Distance(maintree.transform.position, transform.position) < 10f)
            {
                Attack();
            }
        }
        else
        {
            maintree = HomeTree;

            if (Vector3.Distance(maintree.transform.position, transform.position) < 10f)
            {
                Attack();
            }
        }

       

        agent.SetDestination(maintree.transform.position);

    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}