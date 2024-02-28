namespace _project.Scripts.Infrastructure
{
    public class Game
    {
        public static InputSystem InputSystem;
        public static InterfaceSystem InterfaceSystem;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}