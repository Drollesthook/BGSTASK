using System;
using _project.Scripts.Merchant;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public event Action OnPlayerWalkedInRange, OnPlayerWalkedOutOfRange;

    [SerializeField] private InteractButtonShowCase _interactButton;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        OnPlayerWalkedInRange?.Invoke();
        _interactButton.Show();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        OnPlayerWalkedOutOfRange?.Invoke();
        _interactButton.Hide();
    }
    
    
}
