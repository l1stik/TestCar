using UnityEngine;

namespace Core
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private KeyCode _forward = KeyCode.W;
        [SerializeField] private KeyCode _back = KeyCode.S;
        [SerializeField] private KeyCode _left = KeyCode.A;
        [SerializeField] private KeyCode _right = KeyCode.D;
        
        [SerializeField] private float _speed;
        
        private Vector3 _moveDirection;
        private Vector3 _targetVelocity;
        private Vector3 _targetPosition;
        private float _x, _y;

        private void Update()
        {
            var deltaTime = Time.deltaTime;

            _targetPosition = transform.position;
            _moveDirection = Vector3.zero;
            
            if (Input.GetKey(_forward))
            {
                _moveDirection += Vector3.forward;
            }
            
            if (Input.GetKey(_back))
            {
                _moveDirection -= Vector3.forward;
            }
            
            if (Input.GetKey(_left))
            {
                _moveDirection -= Vector3.right;
            }
            
            if (Input.GetKey(_right))
            {
                _moveDirection += Vector3.right;
            }
                
            if (Input.GetMouseButton(0))
            {
                _x += Input.GetAxis("Mouse X") * _speed;
                _y -= Input.GetAxis("Mouse Y") * _speed;

                transform.rotation = Quaternion.Euler(_y, _x, 0);
            }
            
            _targetVelocity = Vector3.Lerp(_targetVelocity, _moveDirection, _speed * deltaTime);

            _targetPosition = transform.position + transform.TransformVector(_targetVelocity * deltaTime * _speed);
            transform.position = _targetPosition;
        }
    }
}