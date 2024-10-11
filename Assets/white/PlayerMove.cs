using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SocialPlatforms;

[ExecuteInEditMode, DisallowMultipleComponent]
public class Playermove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    private Vector3 offset;
    [SerializeField, Range(0.1f, 20.0f)] private float _positionStep = 5.0f;
    [SerializeField, Range(30.0f, 300.0f)] private float _mouseSensitive = 90.0f;
    private Transform _camTransform;

    private Vector3 _startMousePos;
    private Vector3 _presentCamRotation;
    private Vector3 _presentCamPos;

    // Start is called before the first frame update
    void Start()
    {
        _camTransform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraPositionKeyControl();
    }
    private void CameraPositionKeyControl()
    {
        Vector3 campos = _camTransform.position;

        if(Input.GetKey(KeyCode.D)){ campos += _camTransform.right    * Time.deltaTime * _positionStep; } 
        if(Input.GetKey(KeyCode.A)){ campos -= _camTransform.right    * Time.deltaTime * _positionStep; } 
        if(Input.GetKey(KeyCode.W)){ campos += _camTransform.forward  * Time.deltaTime * _positionStep; } 
        if(Input.GetKey(KeyCode.S)){ campos -= _camTransform.forward  * Time.deltaTime * _positionStep; } 
        if(Input.GetKey(KeyCode.Q)){ campos += _camTransform.up       * Time.deltaTime * _positionStep; } 
        if(Input.GetKey(KeyCode.Z)){ campos -= _camTransform.up       * Time.deltaTime * _positionStep; }

        _camTransform.position = campos;
    }
}
