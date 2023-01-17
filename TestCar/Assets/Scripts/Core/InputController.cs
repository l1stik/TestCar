using UnityEngine;
using Zenject;

namespace Core 
{
    public class InputController : MonoBehaviour
    {
        [Inject]
        private FixedJoystick variableJoystick;
        
        private Rigidbody _rigidbody;
        private float speed = 20f;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void FixedUpdate()
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            _rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        private void Update()
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            //transform.rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),  Time.deltaTime * 5);
        }
    }
}