using System;

using _project.Scripts.Infrastructure;

using UnityEngine;

namespace _project.Scripts.Character
{
    public class CharacterAnimationOverrider : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private CharacterSkinSystem _characterSkinSystem;

        private void Start()
        {
            _characterSkinSystem = Game.CharacterSkinSystem;
            _characterSkinSystem.OnSkinChanged += SetAnimationOverrider;
        }

        private void OnDestroy()
        {
            _characterSkinSystem.OnSkinChanged -= SetAnimationOverrider;
        }

        private void SetAnimationOverrider(AnimatorOverrideController overrider)
        {
            animator.runtimeAnimatorController = overrider;
        }
    }
}