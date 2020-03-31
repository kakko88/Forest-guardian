using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BirdPilot : MonoBehaviour
{
    

    private float damage = 20f;

    public float thrust = 10f;
    public Vector3 turnTorque = new Vector3(90f, 25f, 45f);
    public float forceMult = 1000f;
    public float downthrust = 0;
    private float pitch = 0f;
    private float yaw = 0f;
    private float roll = 0f;
    private bool press = true;
    public float Pitch { set { pitch = Mathf.Clamp(value, -1f, 1f); } get { return pitch; } }
    public float Yaw { set { yaw = Mathf.Clamp(value, -1f, 1f); } get { return yaw; } }
    public float Roll { set { roll = Mathf.Clamp(value, -1f, 1f); } get { return roll; } }

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animation>().Play();
            if (press == true)
            {
                thrust += 25f;
                press = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            press = true;
        }
        if (thrust > 10)
        {
            thrust -= 15f * Time.deltaTime;
        }
        else { thrust -= 15f * Time.deltaTime; }

        thrust = Mathf.Clamp(thrust, 2f, 100f);
        downthrust = thrust.Remap(2f, 100f, 20f, 0f);
        if (transform.localPosition.y <= 215f)
        {
            downthrust = 0f;
        }
        roll = Input.GetAxis("Horizontal");

        pitch = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Q))
        {
            yaw = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            yaw = 1f;
        }
        else
        {
            yaw = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        damage = thrust;
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
    }

    private void FixedUpdate()
    {
        rigid.AddRelativeForce(Vector3.forward * thrust * forceMult, ForceMode.Force);
        rigid.AddForce(Vector3.down * downthrust * forceMult, ForceMode.Force);
        rigid.AddRelativeTorque(new Vector3(turnTorque.x * pitch, turnTorque.y * yaw, -turnTorque.z * roll) * forceMult, ForceMode.Force);
        if (rigid.velocity.magnitude > 200)
        {
            rigid.velocity = rigid.velocity.normalized * 200;
        }

    }
}


public static class ExtensionMethods
{

    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}