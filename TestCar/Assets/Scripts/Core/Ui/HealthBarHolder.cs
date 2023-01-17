using UnityEngine;

namespace Core.Ui {
    public class HealthBarHolder : MonoBehaviour {
        
        [SerializeField] 
        private Transform _parentForBars;
       
        [SerializeField] 
        private GameObject _barPrefab;
       
        public Transform ParentForBar => _parentForBars; 
        public GameObject BarPrefab => _barPrefab;
    }
}