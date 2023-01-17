using System.Collections.Generic;
using UnityEngine;

namespace Core.ScriptableObjects {
    
    [CreateAssetMenu]
    public class CarsDataHolder : ScriptableObject 
    {
        [SerializeField] 
        private List<CarData> _carsData;
        
        public List<CarData> CarsData => _carsData;
        public int CarsDataCount => _carsData.Count - 1;
    }
}