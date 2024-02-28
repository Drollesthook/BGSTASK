namespace _project.Scripts.Infrastructure
{
    public class Game
    {
        public static CustomInput CustomInput;
        public GameStateMachine StateMachine;

        public Game()
        {
            StateMachine = new GameStateMachine();
        }
    }
}