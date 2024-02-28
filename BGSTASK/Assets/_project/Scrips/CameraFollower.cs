using UnityEngine;

namespace _project.Scrips
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset = new Vector3(0, 4, -10);
        [SerializeField] private Transform _targetToFollow;
    
        private void Follow()
        {
            transform.position = _targetToFollow.position + _offset;
        }

        private void LateUpdate()
        {
            if(_targetToFollow != null)
                Follow();
        }

        public void SetTargetToFollow(Transform newTarget)
        {
            _targetToFollow = newTarget;
        }
    }
}
