using Core.Enemy;
using Core.Field;
using Core.Ui;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.DI.Installers 
{
    public class GameSystemInstaller : BaseMonoInstaller 
    {
        [SerializeField]
        private FieldController _fieldController;
        
       [SerializeField]
        private FixedJoystick _fixedJoystick;
        
        [SerializeField]
        private EnemiesGenerator _enemiesGenerator;
        
        [SerializeField]
        private CarRenderSystem _carRenderSystem;
        
        [SerializeField]
        private HealthBarHolder _healthBarHolder;
        
        [FormerlySerializedAs("_carsView")] [SerializeField]
        private DisplayedCarsView displayedCarsView;
        
        [FormerlySerializedAs("_carsController")] [SerializeField]
        private DisplayedCarsController displayedCarsController;
        
        public override void InstallBindings() {
            
            BindObjectFromInstance(_healthBarHolder);
            BindObjectFromInstance(_carRenderSystem);
            BindObjectFromInstance(displayedCarsView);
            BindObjectFromInstance(displayedCarsController);
            BindObjectFromInstance(_fieldController);
            BindObjectFromInstance(_enemiesGenerator);
            BindObjectFromInstance(_fixedJoystick);
        }
    }
}