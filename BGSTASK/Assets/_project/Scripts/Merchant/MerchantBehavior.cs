using System;

using UnityEngine;

namespace _project.Scripts.Merchant
{
    public class MerchantBehavior : MonoBehaviour
    {
        public event Action OnPlayerWalkedInRange, OnPlayerWalkedOutOfRange;

        [SerializeField] private InteractButtonShowcase _interactButton;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            OnPlayerWalkedInRange?.Invoke();
            _interactButton.Show();
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            OnPlayerWalkedOutOfRange?.Invoke();
            _interactButton.Hide();
        }
    }
}
