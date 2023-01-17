using Cinemachine;
using UnityEngine;

namespace Core.Car 
{
    public class CarController : MonoBehaviour {
        
        [SerializeField]
        private CarView _carView;
        
        [SerializeField]
        private CinemachineVirtualCamera _virtualCamera;

        public void Init() {
            _virtualCamera.gameObject.SetActive(true);
            _virtualCamera.Priority = 1;
        }

        public void RemoveCarHealth(int value) 
        {
            _carView.DecreaseHealth(value);
        }
    }
}