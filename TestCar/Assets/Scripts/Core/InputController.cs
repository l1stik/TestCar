using UnityEngine;

namespace Core 
{
    public class InputController : MonoBehaviour
    {
        public float speed;
        public FixedJoystick variableJoystick;
        public Rigidbody rb;

        public void FixedUpdate()
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            
            //transform.Rotate(0, variableJoystick.Horizontal, 0);
            //transform.LookAt(transform.forward);
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0, 0, variableJoystick.Horizontal);
        }
    }
}