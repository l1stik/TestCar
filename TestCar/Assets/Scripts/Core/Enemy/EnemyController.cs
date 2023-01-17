using Core.Ui;
using UnityEngine;

namespace Core.Enemy 
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private EnemyView _enemyView;
        
        private void Start() {
            _enemyView.OnTriggerEnterEvent.AddListener(TryDecreaseHealth);
        }
        
        public void InitView(HealthBarHolder healthBarHolder) {
            _enemyView.InitView(healthBarHolder);
        }
        private void TryDecreaseHealth(Collider collider) {

            if (CheckCollisionWithCar(collider)) {
                // не успел доделать
                RemoveCarHealth(0);
            }
        }

        private bool CheckCollisionWithCar(Collider collider) {
            
            return collider.gameObject.tag.Contains("Car");
        }
        
        public void RemoveCarHealth(int value) 
        {
            _enemyView.DecreaseHealth(value);
        }
        
        private void OnDestroy() {
            _enemyView.OnTriggerEnterEvent.RemoveListener(TryDecreaseHealth);
        }
    }
}