using UnityEngine;

namespace Core.Ui 
{
    public class CarRenderSystem : MonoBehaviour 
    {
        [SerializeField] 
        private Transform _carPlace;
        
        [SerializeField] 
        private float _carRotationSpeed = 10f;
        
        public Transform CarPlaceForRender => _carPlace;
        
        private void Update() 
        {
            _carPlace.Rotate(0, _carRotationSpeed * Time.deltaTime, 0);
        }
    }
}