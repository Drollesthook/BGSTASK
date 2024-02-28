using UnityEngine;

namespace _project.Scrips.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game._stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}