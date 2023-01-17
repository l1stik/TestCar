using UnityEngine;
using UnityEngine.UI;

namespace Core.Components 
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] 
        private Slider _healthSlider;

        public void Init(int maxValue) {
            _healthSlider.maxValue = maxValue;
            _healthSlider.value = maxValue;
        }

        public void DecreaseValue(int value) 
        {
            _healthSlider.value -= value;
        }

        public void IncreaseValue(int value) 
        {
            _healthSlider.value += value;
        }
    }
}