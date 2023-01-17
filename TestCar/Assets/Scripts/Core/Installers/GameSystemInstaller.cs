using Core.Car;
using UnityEngine;

namespace Core.Installers {
    public class GameSystemInstaller : BaseMonoInstaller {

        [SerializeField]
        private CarRenderSystem _carRenderSystem;
        
        [SerializeField]
        private CarsView _carsView;
        
        [SerializeField]
        private CarsController _carsController;
        
        public override void InstallBindings() {

            BindObjectFromInstance(_carRenderSystem);
            
            BindObjectFromInstance(_carsView);
            BindObjectFromInstance(_carsController);
        }
    }
}