using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMover : MonoBehaviour
{
    public float Speed { get; private set; }

    private CharacterController _characterController;
    private Axises _moveAxises;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        Speed = 0.8f;
    }

    private void Start() => SetMoveAxis();

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            SpeedUp();

        if (Input.GetKeyUp(KeyCode.LeftShift))
            SpeedDown();

        var moveDirection = _moveAxises.Horizontal * Input.GetAxis("Horizontal") + _moveAxises.Vertical * Input.GetAxis("Vertical");

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);

        _characterController.Move(moveDirection * Speed * 0.1f);
        _characterController.Move(Vector3.down * 0.1f);
    }

    public void LookAt(Vector3 lookPoint)
    {
        var lookRotationAngle = Vector3.SignedAngle(Vector3.right, lookPoint - transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, lookRotationAngle, 0), transform.rotation, 0.8f);
    }

    private void SpeedUp() 
    {
        DOTween.KillAll();

        float lerp = 0;
        float currentSpeed = Speed;

        DOTween.Sequence()
            .AppendCallback(() =>
            {
                if (lerp > 1)
                    DOTween.KillAll();

                Speed = Mathf.Lerp(currentSpeed, 1.2f, lerp);
                lerp += Time.deltaTime / 0.5f;
            }).SetEase(Ease.InSine).SetLoops(-1);
    }

    private void SpeedDown()
    {
        DOTween.KillAll();

        float lerp = 0;
        float currentSpeed = Speed;

        DOTween.Sequence()
            .AppendCallback(() =>
            {
                if (lerp > 1)
                    DOTween.KillAll();

                Speed = Mathf.Lerp(currentSpeed, 0.8f, lerp);
                lerp += Time.deltaTime / 0.5f;
            }).SetEase(Ease.InSine).SetLoops(-1);
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