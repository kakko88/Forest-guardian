using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float attackDMG = 5;
    public GameObject impactEffect; 


    public void Seek(Transform _target)
    {
        target = _target;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;

        }

        Vector3 direction = target.position - transform.position;
        float distancePrFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distancePrFrame)
        {
            HitTarget();
            return;

        }

        transform.Translate(direction.normalized * distancePrFrame, Space.World);
        
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position + new Vector3(0f, 55f, 0f), transform.rotation);
        Destroy(effectIns, 2f);

        if (target.GetComponent<EnemyHealth>().alive == true)
        {
            target.GetComponent<EnemyHealth>().TakeDamage(attackDMG);
        }
        Destroy(gameObject);
    }
}
