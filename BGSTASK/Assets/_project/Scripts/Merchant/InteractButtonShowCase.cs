using DG.Tweening;

using UnityEngine;

namespace _project.Scripts.Merchant
{
    public class InteractButtonShowCase: MonoBehaviour
    {

        [SerializeField] private float YAnimationAmplitude = 1000f;
        [SerializeField] private float animationDuration = 1f;

        private Sequence idleSequence;
        
        
        public void Show()
        {
            gameObject.SetActive(true);
            IdleAnimation();
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
            transform.DOLocalMoveY(0, 0);
            DOTween.Kill(idleSequence);
        }

        private void IdleAnimation()
        {
            idleSequence.Append(transform.DOLocalMoveY(YAnimationAmplitude, animationDuration))
                        .Append(transform.DOLocalMoveY(0f, animationDuration).SetLoops(-1));
        }
    }
}