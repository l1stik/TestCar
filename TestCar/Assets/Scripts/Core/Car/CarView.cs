using Core.Components;
using UnityEngine;

namespace Core.Car 
{
    public class CarView : MonoBehaviour 
    {
        [SerializeField] 
        private HealthBar _healthBar;


        public void DecreaseHealth(int value) {
            _healthBar.DecreaseValue(value);
        }
    }
}