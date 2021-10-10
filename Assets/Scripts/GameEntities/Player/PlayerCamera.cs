using UnityEngine;

namespace Obscurity
{
    public class PlayerCamera : MonoBehaviour
    {        
        [SerializeField] private Transform _playerTransform;

        private Vector3 _offset;

        private void Start() => _offset = transform.position - _playerTransform.position;

        private void Update() => transform.position = Vector3.Lerp(transform.position, _playerTransform.position + _offset, 0.5f);
    }
}