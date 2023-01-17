using UnityEngine;
using Zenject;

namespace Core 
{
    public class MovementController : MonoBehaviour
    {
        [Inject]
        private FixedJoystick variableJoystick;
        
        private Rigidbody _rigidbody;
        private readonly float _speed = 20f;
        private readonly float _speedRotation = 5f;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void FixedUpdate() {
            Vector3 direction = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);
            _rigidbody.AddForce(direction * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            
            if (variableJoystick.Horizontal == 0) {
                return;
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),  Time.fixedDeltaTime * _speedRotation);
        }
    }
}