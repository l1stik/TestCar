using Core.Ui;
using UnityEngine;

namespace Core.Enemy 
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private EnemyView _enemyView;
        
        private void Start() {
            _enemyView.OnTriggerEnterEvent.AddListener(CheckCollisionWithCar);
        }
        
        public void InitView(HealthBarHolder healthBarHolder) {
            _enemyView.InitView(healthBarHolder);
        }

        private void CheckCollisionWithCar(Collider collider) {
            if (collider.gameObject.tag.Contains("Car")) {
                
            }
        }
        
        private void OnDestroy() {
            _enemyView.OnTriggerEnterEvent.RemoveListener(CheckCollisionWithCar);
        }
    }
}