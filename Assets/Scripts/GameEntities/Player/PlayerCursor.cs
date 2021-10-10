using UnityEngine;

namespace Obscurity
{
    public class PlayerCursor : MonoBehaviour
    {
        public static Vector3 CursorWorldPosition { get; private set; }
        public static IIteractable CatchedEntity { get; private set; }

        private Camera _playerCamera;
        private Collider _currentCatchedCollider = null;

        private void Awake()
        {
            _playerCamera = Camera.main;
        }

        private void Update() => Raycast();

        private void Raycast()
        {
            var mouseWorldPosition = _playerCamera.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(mouseWorldPosition, out RaycastHit hits);

            CursorWorldPosition = hits.point;
            _currentCatchedCollider = hits.collider;

            if (hits.collider && hits.collider != _currentCatchedCollider)
                CatchedEntity = hits.collider.gameObject.GetComponent<IIteractable>();
        }
    }
}