using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode, DisallowMultipleComponent]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float distance = 20.0f;
    [SerializeField] private float polarAngle = 45.0f;
    [SerializeField] private float azimuthalAngle = 45.0f;
    [SerializeField] private float minPolarAngle = 5.0f;
    [SerializeField] private float maxPolarAngle = 75.0f;
    [SerializeField] private float mouseXSensitivity = 5.0f;
    [SerializeField] private float mouseYSensitivity = 5.0f;
    [SerializeField] private float scrollSensitivity = 5.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    private Vector3 offset;
    [SerializeField, Range(0.1f, 20.0f)] private float _positionStep = 5.0f;
    [SerializeField, Range(30.0f, 300.0f)] private float _mouseSensitive = 90.0f;

    private Transform _camTransform;

    private Vector3 _startMousePos;
    private Vector3 _presentCamRotation;
    private Vector3 _presentCamPos;

    void Start()
    {
        _camTransform = this.gameObject.transform;
    }
    void Update()
    {
        CameraRotationMouseControl();
        // マウスホイールでの拡大縮小

    }

    void updateAngle(float x, float y)
    {
        azimuthalAngle -= x * mouseXSensitivity;
        azimuthalAngle = Mathf.Repeat(azimuthalAngle, 360);

        polarAngle += y * mouseYSensitivity;
        polarAngle = Mathf.Clamp(polarAngle, minPolarAngle, maxPolarAngle);
    }

    private void CameraRotationMouseControl()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _startMousePos = Input.mousePosition;
            _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
            _presentCamRotation.y = _camTransform.transform.eulerAngles.y; 
        }
        if(Input.GetMouseButton(1))
        {
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            float eulerX = _presentCamRotation.x + y * _mouseSensitive;
            float eulerY = _presentCamRotation.y + x * _mouseSensitive;

            _camTransform.rotation = Quaternion.Euler (eulerX, eulerY, 0);
        }
    }
}
