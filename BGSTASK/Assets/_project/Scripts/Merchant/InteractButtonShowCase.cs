using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Merchant
{
    public class InteractButtonShowCase: MonoBehaviour
    {
        
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void IdleAnimation()
        {
            
        }
    }
}