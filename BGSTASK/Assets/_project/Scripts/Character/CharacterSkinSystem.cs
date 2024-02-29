using System;

using UnityEngine;

namespace _project.Scripts.Character
{
    public class CharacterSkinSystem
    {
        public event Action<AnimatorOverrideController> OnSkinChanged;

        public void SetNewAnimationOverride(AnimatorOverrideController overrideController)
        {
            OnSkinChanged?.Invoke(overrideController);
        }
    }
}