using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    public void ToggleWalkAnimation(bool toggle)
    {
        _animator.SetBool(IsWalking, toggle);
    }
}
