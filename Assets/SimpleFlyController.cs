using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
    public class SimpleFlyController : MonoBehaviour
    {

        
        public float thrust = 10f;
        public Vector3 turnTorque = new Vector3(90f, 25f, 45f);
        public float forceMult = 1000f;
        
        private float pitch = 0f;
        private float yaw = 0f;
        private float roll = 0f;
        private bool press = true;
        public float Pitch { set { pitch = Mathf.Clamp(value, -1f, 1f); } get { return pitch; } }
        public float Yaw { set { yaw = Mathf.Clamp(value, -1f, 1f); } get { return yaw; } }
        public float Roll { set { roll = Mathf.Clamp(value, -1f, 1f); } get { return roll; } }

        private Rigidbody xrigid;

        private void Awake()
        {
            xrigid = GetComponent<Rigidbody>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space))
        {
            if (press == true)
            {
                thrust += 200f;
                press = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            
            press = true;
        }
        thrust -= 10f * Time.deltaTime;
        thrust = Mathf.Clamp(thrust, 0f, 50f);
        roll = Input.GetAxis("Horizontal");

        pitch = Input.GetAxis("Vertical");

        }

        private void FixedUpdate()
        {
            xrigid.AddRelativeForce(Vector3.forward * thrust * forceMult, ForceMode.Force);
            xrigid.AddRelativeTorque(new Vector3(turnTorque.x * pitch, turnTorque.y * yaw, -turnTorque.z * roll) * forceMult, ForceMode.Force);
        }
    }