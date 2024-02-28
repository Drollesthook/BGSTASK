namespace _project.Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>("Gameplay Scene");

        private void RegisterServices()
        {
            Game.CustomInput = new CustomInput();
            Game.InterfaceSystem = new InterfaceSystem();
        }

        public void Exit()
        {
        }
    }
}