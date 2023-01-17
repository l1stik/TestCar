using Core.Installers;
using UnityEngine;

namespace Core.ScriptableObjects
{
    public class DtoInstaller : BaseMonoInstaller 
    {

        [SerializeField] 
        private CarsDataHolder _carsDataHolder;

        public override void InstallBindings()
        {
            BindScriptableObject(_carsDataHolder);
        }
    }
}