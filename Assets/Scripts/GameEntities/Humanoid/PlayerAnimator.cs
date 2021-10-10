using UnityEngine;

namespace Obscurity
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMover;
        [SerializeField] private float _angleOffset;
        [SerializeField] private Transform _playerTransform;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            float _playerRotation = _playerTransform.eulerAngles.y * Mathf.Deg2Rad + _angleOffset * Mathf.Deg2Rad;

            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            var rotatedIntut = new Vector2()
            {
                x = input.x * Mathf.Cos(_playerRotation) - input.y * Mathf.Sin(_playerRotation),
                y = input.y * Mathf.Cos(_playerRotation) + input.x * Mathf.Sin(_playerRotation),
            };

            rotatedIntut = Vector2.ClampMagnitude(rotatedIntut, 1f) * _playerMover.Speed;

            _animator.SetFloat("VelocityX", rotatedIntut.x);
            _animator.SetFloat("VelocityZ", rotatedIntut.y);
        }
    }
}