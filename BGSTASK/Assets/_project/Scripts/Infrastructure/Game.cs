namespace _project.Scripts.Infrastructure
{
    public class Game
    {
        public static CustomInput CustomInput;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}