using UnityEngine;

namespace Obscurity
{
    public class PlayerMovement : HumanoidMovement
    {
        [SerializeField] private PlayerCamera _playerCamera;
        [SerializeField] private float _speedMultiplier;

        private CharacterController _characterController;
        private Axises _moveAxises;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            SetMoveAxis();
        }

        private void Update()
        {
            Move();
            LookAt(PlayerCursor.CursorWorldPosition);
        }

        public void Move()
        {
            var moveDirection = _moveAxises.Horizontal * Input.GetAxis("Horizontal") + _moveAxises.Vertical * Input.GetAxis("Vertical");

            moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

            _characterController.Move(moveDirection * Speed * Time.deltaTime * _speedMultiplier);
            _characterController.Move(Vector3.down * 0.1f);

            if (Input.GetKeyDown(KeyCode.LeftShift))
                SpeedUp();

            if (Input.GetKeyUp(KeyCode.LeftShift))
                SpeedDown();
        }

        public void LookAt(Vector3 lookPoint)
        {
            var lookRotationAngle = Vector3.SignedAngle(Vector3.right, lookPoint - transform.position, Vector3.up);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, lookRotationAngle, 0), transform.rotation, 0.8f);
        }

        private void SetMoveAxis()
        {
            float rotateAxisAngle = _playerCamera.transform.rotation.eulerAngles.y;

            _moveAxises.Horizontal = new Vector3()
            {
                x = Mathf.Cos(Mathf.Deg2Rad * rotateAxisAngle),
                z = -Mathf.Sin(Mathf.Deg2Rad * rotateAxisAngle)
            };

            _moveAxises.Vertical = new Vector3()
            {
                x = Mathf.Sin(Mathf.Deg2Rad * rotateAxisAngle),
                z = Mathf.Cos(Mathf.Deg2Rad * rotateAxisAngle)
            };
        }
    }

    public struct Axises
    {
        public Vector3 Vertical;
        public Vector3 Horizontal;
    };
}