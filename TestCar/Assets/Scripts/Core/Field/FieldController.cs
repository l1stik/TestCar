using Core.Car;
using Core.Enemy;
using Core.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.Field 
{
    public class FieldController : MonoBehaviour {

        [SerializeField]
        private Transform _placeForSpawnCar;
        
        [Inject] 
        private EnemiesGenerator _enemiesGenerator;
        
        [Inject] 
        private DiContainer _diContainer;

        public void StartGame(CarData carData) {
            SpawnCar(carData);
            _enemiesGenerator.Generate();
        }

        private void SpawnCar(CarData carData) {
            var car = Instantiate(carData.CarPrefab);
            car.transform.position = _placeForSpawnCar.position;
            car.GetComponent<CarController>().Init();
            _diContainer.InstantiateComponent<MovementController>(car);
        }
        
        private void OnTriggerExit(Collider other) {
            if (other.gameObject.tag.Contains("Car")) {
                SceneManager.LoadScene(0);
            }
        }
    }
}