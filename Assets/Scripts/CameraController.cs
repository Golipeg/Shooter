using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraWalkingAnchor;
    [SerializeField] private Transform _cameraAimingAnchor;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _cameraInterpolationSpeed=5f;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _walkingMaxMinPitch;
    [SerializeField] private Vector2 _aimingMaxMinPitch;
    private Transform _cameraAnchor;
    private Vector2 _maxMinPitch;
    private float _pitch;
    private float _yaw;
    
    public void SetAimingMode(bool isAiming)
    {
        _cameraAnchor = isAiming ? _cameraAimingAnchor : _cameraWalkingAnchor;
        _maxMinPitch = isAiming ? _aimingMaxMinPitch : _walkingMaxMinPitch;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle > 360) angle -= 360;
        if (angle < 360) angle += 360;
        return Mathf.Clamp(angle, max, min);
    }

    private void Awake()
    {
        SetAimingMode(false);
    }

    private void LateUpdate()
    {
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _cameraAnchor.position,Time.deltaTime*_cameraInterpolationSpeed);
        _camera.transform.rotation=Quaternion.RotateTowards(_camera.transform.rotation,_cameraAnchor.rotation,Time.deltaTime*_cameraInterpolationSpeed);
        
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");
        
        var yawDelta = x * _rotationSpeed * Time.deltaTime;
        var pitchDelta = -y * _rotationSpeed * Time.deltaTime;
        _pitch = ClampAngle(_pitch + pitchDelta, _maxMinPitch.x, _maxMinPitch.y);
        _yaw += yawDelta;

        //var resultPitch = Mathf.Clamp(transform.rotation.eulerAngles.z + pitchDelta, _maxPitch, _minPitch);
        transform.position = _target.position;
        transform.rotation=Quaternion.Euler(_pitch,_yaw,0);
        //код на 49  минуте
        
    }
}
