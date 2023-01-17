using System.Collections.Generic;
using Core.Car;
using Core.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Core {
    public class CarsController : MonoBehaviour
    {
        [Inject] 
        private CarRenderSystem _carRenderSystem;
        
        [Inject]
        private CarsDataHolder _carsDataHolder;

        [Inject]
        private CarsView _carsView;

        public void Start() {
            _carsView.OnNextCarButtonClick.AddListener(GenerateNextCar);
            GenerateNextCar();
        }
        
        private GameObject _currentCarGameObject;
        private int _currentCarIndex;

        private List<GameObject> _poolInstancesCar = new();

        private void GenerateNextCar() {
            if (_currentCarIndex > _carsDataHolder.CarsDataCount) {
                _currentCarIndex = 0;
            }

            _currentCarGameObject?.SetActive(false);
            
            var carData = _carsDataHolder.CarsData[_currentCarIndex];

            var carFromPool = _poolInstancesCar.Find(x => x.name.Contains(carData.CarPrefab.name));
            if (carFromPool == null) {
                var car = UnityEngine.Object.Instantiate(carData.CarPrefab);
                
                var carTransform = car.transform;
                carTransform.SetParent(_carRenderSystem.CarPlaceForRender);
                carTransform.rotation = _carRenderSystem.CarPlaceForRender.rotation;
                carTransform.position = _carRenderSystem.CarPlaceForRender.position;
                
                _poolInstancesCar.Add(car);
                _currentCarGameObject = car;
            } else {
                carFromPool.SetActive(true);
                _currentCarGameObject = carFromPool;
            }
            
            _currentCarIndex++;
            _currentCarGameObject.transform.rotation = _carRenderSystem.CarPlaceForRender.rotation;

            _carsView.ShowNextCar(carData.Health.ToString(), carData.Damage.ToString());
        }

        ~CarsController() {
            _carsView.OnNextCarButtonClick.RemoveListener(GenerateNextCar);
        }
    }
}