using UnityEngine;
using Zenject;

namespace Core.Car 
{
    public class CarController : MonoBehaviour {
        
        [Inject]
        private CarView _carView;
        
        public void RemoveCarHealth(int value) 
        {
            _carView.DecreaseHealth(value);
        }
    }
}