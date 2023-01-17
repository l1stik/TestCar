using System.Collections.Generic;
using Core.Field;
using Core.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Core.Ui 
{
    public class DisplayedCarsController : MonoBehaviour
    {
        [Inject] 
        private CarRenderSystem _carRenderSystem;
        
        [Inject]
        private CarsDataHolder _carsDataHolder;

        [Inject]
        private DisplayedCarsView _displayedCarsView;
         
        [Inject]
        private FieldController _fieldController;
         
        private CarData _currentCarData;
        private GameObject _currentCarGameObject;
        private int _currentCarIndex;

        private List<GameObject> _poolInstancesCar = new();
        
        public void Start() 
        {
            _displayedCarsView.OnNextCarButtonClick.AddListener(ShowNextCar);
            _displayedCarsView.OnChooseCarButtonClick.AddListener(StartGame);
            ShowNextCar();
        }

        private void StartGame() 
        {
            _displayedCarsView.Hide();
            ClearCarsPoolWithDestroy();
            
            _fieldController.StartGame(_currentCarData);
        }

        private void ClearCarsPoolWithDestroy() 
        {
            foreach (var car in _poolInstancesCar)
            {
                Destroy(car);
            }
            _poolInstancesCar.Clear();
        }
        
        private void ShowNextCar() 
        {
            if (_currentCarIndex > _carsDataHolder.CarsDataCount) 
            {
                _currentCarIndex = 0;
            }

            _currentCarGameObject?.SetActive(false);
            
            _currentCarData = _carsDataHolder.CarsData[_currentCarIndex];

            var carFromPool = _poolInstancesCar.Find(x => x.name.Contains(_currentCarData.CarPrefab.name));
            if (carFromPool == null) 
            {
                var car = UnityEngine.Object.Instantiate(_currentCarData.CarPrefab);
                
                var carTransform = car.transform;
                carTransform.SetParent(_carRenderSystem.CarPlaceForRender);
                carTransform.rotation = _carRenderSystem.CarPlaceForRender.rotation;
                carTransform.position = _carRenderSystem.CarPlaceForRender.position;
                
                _poolInstancesCar.Add(car);
                _currentCarGameObject = car;
            } else 
            {
                carFromPool.SetActive(true);
                _currentCarGameObject = carFromPool;
            }
            
            _currentCarIndex++;
            _currentCarGameObject.transform.rotation = _carRenderSystem.CarPlaceForRender.rotation;

            _displayedCarsView.ShowNextCar(_currentCarData.Health.ToString(), _currentCarData.Damage.ToString());
        }

        private  void OnDestroy() 
        {
            _displayedCarsView.OnChooseCarButtonClick.RemoveListener(StartGame);
            _displayedCarsView.OnNextCarButtonClick.RemoveListener(ShowNextCar);
        }
    }
}