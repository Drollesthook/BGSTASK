using UnityEngine;

namespace _project.Scripts
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset = new Vector3(0, 4, -10);
        private Transform _targetToFollow;
    
        private void Follow()
        {
            transform.position = _targetToFollow.position + _offset;
        }

        private void LateUpdate()
        {
            if(_targetToFollow != null)
                Follow();
        }

        public void SetTargetToFollow(GameObject newTarget)
        {
            _targetToFollow = newTarget.transform;
        }
    }
}
