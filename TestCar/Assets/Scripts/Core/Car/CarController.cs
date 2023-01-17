using System;
using Cinemachine;
using UnityEngine;

namespace Core.Car 
{
    public class CarController : MonoBehaviour 
    {
        [SerializeField]
        private CarView _carView;
        
        [SerializeField]
        private CinemachineVirtualCamera _virtualCamera;

        public void Init()
        {
            _virtualCamera.gameObject.SetActive(true);
            _virtualCamera.Priority = 1;
            
            _carView.OnTriggerEnterEvent.AddListener(TryDecreaseHealth);
        }

        private void TryDecreaseHealth(Collider collider) {

            if (CheckCollisionWithEnemy(collider)) {
                // не успел доделать
                RemoveCarHealth(0);
            }
        }

        private bool CheckCollisionWithEnemy(Collider collider) {
            
            return collider.gameObject.tag.Contains("Enemy");
        }
        
        public void RemoveCarHealth(int value) 
        {
            _carView.DecreaseHealth(value);
        }
        
        private void OnDestroy() {
            _carView.OnTriggerEnterEvent.RemoveListener(TryDecreaseHealth);
        }
    }
}