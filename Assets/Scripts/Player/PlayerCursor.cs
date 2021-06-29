using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    private Camera _playerCamera;

    public Vector3 CursorWorldPosition { get; private set; }
    public IIteractable CatchedEntity { get; private set; }

    private void Start() => _playerCamera = PlayerCamera.Instance.CameraComponent;
    
    private void Update()
    {
        var mouseWorldPosition = _playerCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseWorldPosition, out RaycastHit hits);
        CursorWorldPosition = hits.point;

        CatchedEntity = hits.collider.gameObject.GetComponent<MonoBehaviour>() as IIteractable;

        if (Input.GetMouseButtonDown(0) && CatchedEntity != null && CatchedEntity is Building building)
            ActionsLogger.Instance.Log($"Builded by {building.Owner}");
    }
}