using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    public void ToggleWalkAnimation(bool toggle, float xInput)
    {
        _animator.SetBool(IsWalking, toggle);
        if (xInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        if (xInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
