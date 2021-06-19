using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private CharacterController _characterController;
    private Axises _moveAxises;
    private float _speed = 1;

    private void Awake() => _characterController = GetComponent<CharacterController>();
    private void Start() => SetMoveAxis();

    public void Move()
    {
        var moveDirection = _moveAxises.Horizontal * Input.GetAxis("Horizontal") + _moveAxises.Vertical * Input.GetAxis("Vertical");
        _characterController.Move(moveDirection * _speed * 0.1f);
        _characterController.Move(Vector3.down * 0.1f);
    }

    public void LookAt(Vector3 lookPoint)
    {
        var lookRotationAngle = Vector3.SignedAngle(Vector3.right, lookPoint - transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, lookRotationAngle, 0), transform.rotation, 0.8f);
    }

    private void SetMoveAxis()
    {
        float rotateAxisAngle = PlayerCamera.Instance.transform.rotation.eulerAngles.y;

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