using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPilot : MonoBehaviour
{
    public Rigidbody r;

    //public float rollRate = 70;
    // public float pitchRate = 50;


 


    private float topSpeed;
    private float acceleration;
    public float speed;

    public float thrust = 0;

    public float gravityConstant = 9;

    public Vector3 com = Vector3.zero;

    public FlappyAnimation _FlappyAnimation;

    void Start()
    {
        r.centerOfMass = com; // set center of mass


        topSpeed = 200;
        acceleration = 0;

    }

    void Update()
    {

       //Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
       //float bias = 0.9f;
       //Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);
       //Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);

        speed = r.velocity.magnitude; // get speed

        speed -= transform.forward.y * Time.deltaTime * speed;



        if (Input.GetKeyDown("space"))
        {
            thrust = 100; // if space is spressed, then accelerate
            acceleration += 10;
            GetComponent<Animation>().Play();
        }
        else
        {
            thrust = -1f; // if not, dont accelerate
            if (speed == 0)
            {
                thrust = 0f;
            }
        }
        transform.Rotate(Input.GetAxis("Vertical") * 2.0f, 0.0f, -Input.GetAxis("Horizontal") * 2.0f);
        acceleration = Mathf.Clamp(acceleration + (acceleration * thrust * Time.deltaTime), 0, topSpeed); // make sure not to go faster than top speed
        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeight > transform.position.y)
        {
            r.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }

    }

    void FixedUpdate()
    {
        // r.AddRelativeTorque(Input.GetAxis("Vertical") * pitchRate * Time.fixedDeltaTime, 0, -Input.GetAxis("Horizontal") * rollRate * Time.fixedDeltaTime, ForceMode.Acceleration); // pitch and yaw

        r.drag = 1 + (Mathf.Abs(thrust) / topSpeed); // some fancy physics to set a terminal velocity
        r.AddRelativeForce(0, 0, acceleration, ForceMode.Acceleration); // the actual physics for acceleration 

        r.AddForce(0, -gravityConstant, 0); // my own gravity (disable gravity on the rigidbody component
        r.AddRelativeForce(0, Mathf.Clamp((speed / topSpeed) * gravityConstant * 2, 0, gravityConstant), 0); // add lift based on speed, unitl lift 
                                                                                                             // is the same as downward force (about 1/4 of top speed)
    }
}