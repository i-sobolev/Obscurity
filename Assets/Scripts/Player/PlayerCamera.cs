using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera Instance { private set; get; }
    public Camera CameraComponent { private set; get; }

    private Transform _playerTransform;
    private Vector3 _offset;

    private void Awake()
    {
        Instance = this;
        CameraComponent = GetComponent<Camera>();
    }

    private void Start()
    {
        _playerTransform = Player.Instance.transform;
        _offset = transform.position - _playerTransform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _playerTransform.position + _offset, 0.5f);
    }
}