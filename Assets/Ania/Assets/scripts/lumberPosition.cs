using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class lumberPosition : MonoBehaviour
{
    public Camera cam;
    //public GameObject maintree;
    public NavMeshAgent agent;


    void Start()
    {
        
        setPosition();
        findTree();
        
    }

    // Update is called once per frame
    void Update()
    {

        /*GameObject lumber = GameObject.Find("Cube");

        float speed = 0.5f;
        float step =  speed * Time.deltaTime; // calculate distance to move

        transform.position = Vector3.MoveTowards(lumber.transform.position, maintree.transform.position, step );
        
        */
        /*Ray ray = cam.ScreenPointToRay(maintree.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(maintree.transform.position);
        }*/
    }
    
    public void setPosition()
    {
        float angleInRadians = Mathf.PI * (Random.Range(0,20) * .1f) ;
        //var lumber = this.gameObject;
        transform.position = new Vector3(7*Mathf.Cos(angleInRadians), 1, 7*Mathf.Sin(angleInRadians));
    }

    public void findTree()
    {
        //GameObject lumber = GameObject.Find("Lumbers");
        //GameObject lumber = this.gameObject;
        GameObject tree1 = GameObject.Find("tree1");
        GameObject tree2 = GameObject.Find("tree2");
        GameObject tree3 = GameObject.Find("tree3");
        GameObject tree4 = GameObject.Find("tree4");
        GameObject maintree = new GameObject();

        float shortestDistance = Mathf.Min(Vector3.Distance(tree1.transform.position, transform.position),
            Vector3.Distance(tree2.transform.position, transform.position),
            Vector3.Distance(tree3.transform.position, transform.position), Vector3.Distance(tree4.transform.position, transform.position));
        
        
        if (shortestDistance == Vector3.Distance(tree1.transform.position, transform.position))
        {
            maintree = tree1;
        } 
        else if (shortestDistance == Vector3.Distance(tree2.transform.position, transform.position))
        {
            maintree = tree2;
        }
        else if (shortestDistance == Vector3.Distance(tree3.transform.position, transform.position))
        {
            maintree = tree3;
        }
        else if (shortestDistance ==  Vector3.Distance(tree4.transform.position, transform.position));
        {
            maintree = tree4;
        }
       
        //float dis = agent.remainingDistance();
        //float closestTree = Mathf.Min(agent
        //agent = this.GetComponent<NavMeshAgent>();
        //agent.SetDestination(maintree.transform.position);
        //Ray ray = cam.ScreenPointToRay(maintree.transform.position);
        //RaycastHit hit;
        
        agent.SetDestination(maintree.transform.position);
        
    }
}
