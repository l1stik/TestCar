using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core {
    public class CarsView : MonoBehaviour {
        
        [SerializeField] 
        private Button _chooseCarButton;
        
        [SerializeField] 
        private Button _nextCarButton;
        
        [SerializeField] 
        private TextMeshProUGUI _healthText;
        
        [SerializeField] 
        private TextMeshProUGUI _damageText;
        
        [HideInInspector] 
        public UnityEvent OnChooseCarButtonClick = new UnityEvent();

        [HideInInspector] 
        public UnityEvent OnNextCarButtonClick = new UnityEvent();

        private void Awake() {
            _chooseCarButton.onClick.AddListener(OnChooseCarButtonClickInvoke);
            _nextCarButton.onClick.AddListener(OnNextCarButtonClickInvoke);
        }

        private void OnChooseCarButtonClickInvoke() {
            OnChooseCarButtonClick?.Invoke();
        }
        
        private void OnNextCarButtonClickInvoke() {
            OnNextCarButtonClick?.Invoke();
        }

        public void ShowNextCar(string healthValue, string damageValue) {

            _healthText.text = healthValue;
            _damageText.text = damageValue;

        }
        
        private void OnDestroy() {
            _chooseCarButton.onClick.RemoveListener(OnChooseCarButtonClickInvoke);
            _nextCarButton.onClick.RemoveListener(OnNextCarButtonClickInvoke);
        }
    }
}