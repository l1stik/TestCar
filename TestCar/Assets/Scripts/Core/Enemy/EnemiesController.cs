using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Enemy {
    public class EnemiesController : MonoBehaviour 
    {
        [SerializeField] 
        private GameObject _enemyPrefab;
        
        [SerializeField] 
        private List<GameObject> _placesForSpawnEnemy;
        
        private List<GameObject> _instancesEnemy = new();

        private void Start() 
        {
            Generate();
        }

        public void Generate() 
        {
            var count = Random.Range(10, 50);
            var places = new List<GameObject>(_placesForSpawnEnemy);

            for (var i = 0; i < count; i++) 
            {
                var enemy = Instantiate(_enemyPrefab);
                _instancesEnemy.Add(enemy);
                
                var randomPlaceNumber = Random.Range(0, places.Count);
                var place = places[randomPlaceNumber];
                
                enemy.transform.position = place.transform.position + Vector3.up;
                
                places.Remove(place);
            }
        }
        
        public void ClearField() 
        {
            foreach (var enemy in _instancesEnemy) {
                Destroy(enemy);
            }

            _instancesEnemy.Clear();
        }
    }
}
