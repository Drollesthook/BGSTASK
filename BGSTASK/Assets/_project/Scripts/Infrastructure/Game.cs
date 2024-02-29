using _project.Scripts.Character;

namespace _project.Scripts.Infrastructure
{
    public class Game
    {
        public static InputSystem InputSystem;
        public static InterfaceSystem InterfaceSystem;
        public static CharacterInventorySystem CharacterInventorySystem;
        public static CharacterSkinSystem CharacterSkinSystem;
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}