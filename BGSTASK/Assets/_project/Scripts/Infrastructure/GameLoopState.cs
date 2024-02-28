namespace _project.Scripts.Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine stateMachine;

        public GameLoopState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}