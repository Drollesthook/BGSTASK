using _project.Scripts.Infrastructure;

using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scripts.Character
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField, Range(4, 12)] private float _baseSpeed = 8;
        [SerializeField, Range(1, 2)] private float _targetSprintMultiplier = 1.5f;
        [SerializeField] private Rigidbody2D _characterRb;
        [SerializeField] private CharacterAnimation _characterAnimation;

        private InputSystem _inputSystem;
        private float _sprintMultiplier = 1;
        private Vector2 _inputVector = Vector2.zero;

        private void Awake()
        {
            _inputSystem = Game.InputSystem;
        }

        private void Update()
        {
            MoveInDirection();
        }

        private void OnEnable()
        {
            _inputSystem.Player.Enable();
            _inputSystem.Player.Movement.performed += OnMovementInputPerformed;
            _inputSystem.Player.Movement.canceled += OnMovementInputCancelled;
            _inputSystem.Player.Sprint.performed += OnSprintInputPerformed;
            _inputSystem.Player.Sprint.canceled += OnSprintInputCancelled;
        }

        private void OnDisable()
        {
            _inputSystem.Player.Disable();
            _inputSystem.Player.Movement.performed -= OnMovementInputPerformed;
            _inputSystem.Player.Movement.canceled -= OnMovementInputCancelled;
            _inputSystem.Player.Sprint.performed -= OnSprintInputPerformed;
            _inputSystem.Player.Sprint.canceled -= OnSprintInputCancelled;
        }

        private void OnMovementInputPerformed(InputAction.CallbackContext value)
        {
            _inputVector = value.ReadValue<Vector2>().normalized;
            _characterAnimation.ToggleWalkAnimation(true, _inputVector.x);
        }

        private void OnMovementInputCancelled(InputAction.CallbackContext value)
        {
            _inputVector = Vector2.zero;
            _characterAnimation.ToggleWalkAnimation(false, 0);
        }
        
        private void OnSprintInputPerformed(InputAction.CallbackContext value)
        {
            _sprintMultiplier = _targetSprintMultiplier;
        }

        private void OnSprintInputCancelled(InputAction.CallbackContext value)
        {
            _sprintMultiplier = 1;
        }
        
        private void MoveInDirection()
        {
            _characterRb.velocity = _inputVector * _baseSpeed * _sprintMultiplier;
        }
    }
}
