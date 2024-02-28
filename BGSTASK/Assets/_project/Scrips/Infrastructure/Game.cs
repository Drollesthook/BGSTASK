namespace _project.Scrips.Infrastructure
{
    public class Game
    {
        public static CustomInput CustomInput;
        public GameStateMachine _stateMachine;

        public Game()
        {
            _stateMachine = new GameStateMachine();
        }
    }
}