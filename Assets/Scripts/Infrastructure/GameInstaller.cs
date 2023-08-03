using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller: MonoInstaller
    {
        [SerializeField]
        private RocketMovement _rocketMovement;
        [SerializeField]
        private VariableJoystick _variableJoystick;
        
        public override void InstallBindings()
        {
            Container.Bind<RocketMovement>().To<RocketMovement>().FromInstance(_rocketMovement).AsSingle();
            Container.Bind<VariableJoystick>().To<VariableJoystick>().FromInstance(_variableJoystick).AsSingle();
        }
    }
}