using Core.Ui;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Installers {
    public class GameSystemInstaller : BaseMonoInstaller {

        [SerializeField]
        private CarRenderSystem _carRenderSystem;
        
        [FormerlySerializedAs("_carsView")] [SerializeField]
        private DisplayedCarsView displayedCarsView;
        
        [FormerlySerializedAs("_carsController")] [SerializeField]
        private DisplayedCarsController displayedCarsController;
        
        public override void InstallBindings() {

            BindObjectFromInstance(_carRenderSystem);
            
            BindObjectFromInstance(displayedCarsView);
            BindObjectFromInstance(displayedCarsController);
        }
    }
}