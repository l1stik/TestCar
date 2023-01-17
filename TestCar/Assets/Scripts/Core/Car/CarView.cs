using Core.Components;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Car 
{
    public class CarView : MonoBehaviour 
    {
        [SerializeField] 
        private HealthBar _healthBar;
        
        [HideInInspector] 
        public UnityEvent<Collider> OnTriggerEnterEvent = new();

        private void OnTriggerEnter(Collider other) {
            OnTriggerEnterEvent?.Invoke(other);
        }

        public void DecreaseHealth(int value) {
            _healthBar.DecreaseValue(value);
        }
    }
}