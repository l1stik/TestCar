using UnityEngine;
using Zenject;

namespace Core 
{
    public class MovementController : MonoBehaviour
    {
        [Inject]
        private FixedJoystick variableJoystick;
        
        private Rigidbody _rigidbody;
        private float speed = 20f;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void FixedUpdate() {
            Vector3 direction = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
            _rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            
            if (variableJoystick.Horizontal == 0) {
                return;
            } 
            //Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            //transform.rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),  Time.deltaTime * 5);
        }

    }
}