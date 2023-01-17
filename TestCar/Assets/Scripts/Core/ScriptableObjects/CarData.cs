using UnityEngine;

namespace Core.ScriptableObjects 
{
    [CreateAssetMenu]
    public class CarData : ScriptableObject {
        
        [SerializeField] private GameObject _carPrefab;
        [SerializeField] private float _health;
        [SerializeField] private float _damage;
        
        public GameObject CarPrefab => _carPrefab;
        public float Health => _health;
        public float Damage => _damage;
    }
}