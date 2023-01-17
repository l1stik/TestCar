using Core.Components;
using Core.Ui;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core.Enemy 
{
    public class EnemyView : MonoBehaviour {
        
        private HealthBar _healthBar;

        [HideInInspector] 
        public UnityEvent<Collider> OnTriggerEnterEvent = new();

        [SerializeField] 
        private float _healthBarOffset = 5f;

        public void InitView(HealthBarHolder healthBarHolder) {
            
            _healthBar = Instantiate(healthBarHolder.BarPrefab, healthBarHolder.ParentForBar, false).GetComponent<HealthBar>();
            _healthBar.transform.SetParent(healthBarHolder.ParentForBar);
            
            var position = transform.position;
            _healthBar.gameObject.transform.position = Camera.main.WorldToScreenPoint(
                new Vector3(position.x, position.y + _healthBarOffset, position.z));
        }

        private void OnTriggerEnter(Collider other) {
            OnTriggerEnterEvent?.Invoke(other);
        }
        
        public void DecreaseHealth(int value) {
            _healthBar.DecreaseValue(value);
        }
    }
}