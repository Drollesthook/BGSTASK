using System;

using UnityEngine;
using UnityEngine.InputSystem;

namespace _project.Scrips
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField, Range(4, 12)] private float _baseSpeed = 8;
        [SerializeField, Range(1, 2)] private float _targetSprintMultiplier = 1.5f;
        [SerializeField] private Rigidbody2D _characterRb;

        private CustomInput _input;
        private float _sprintMultiplier = 1;
        private Vector2 _inputVector = Vector2.zero;

        private void Awake()
        {
            _input = new CustomInput();
        }

        private void Update()
        {
            MoveInDirection();
        }

        private void OnEnable()
        {
            _input.Enable();
            _input.Player.Movement.performed += OnMovementInputPerformed;
            _input.Player.Movement.canceled += OnMovementInputCancelled;
            _input.Player.Sprint.performed += OnSprintInputPerformed;
            _input.Player.Sprint.canceled += OnSprintInputCancelled;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Player.Movement.performed -= OnMovementInputPerformed;
            _input.Player.Movement.canceled -= OnMovementInputCancelled;
            _input.Player.Sprint.performed -= OnSprintInputPerformed;
            _input.Player.Sprint.canceled -= OnSprintInputCancelled;
        }

        private void OnMovementInputPerformed(InputAction.CallbackContext value)
        {
            _inputVector = value.ReadValue<Vector2>().normalized;
        }

        private void OnMovementInputCancelled(InputAction.CallbackContext value)
        {
            _inputVector = Vector2.zero;
        }

        private void MoveInDirection()
        {
            _characterRb.velocity = _inputVector * _baseSpeed * _sprintMultiplier;
        }

        private void OnSprintInputPerformed(InputAction.CallbackContext value)
        {
            _sprintMultiplier = _targetSprintMultiplier;
        }

        private void OnSprintInputCancelled(InputAction.CallbackContext value)
        {
            _sprintMultiplier = 1;
        }
    }
}
