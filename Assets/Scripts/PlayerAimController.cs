using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAimController : MonoBehaviour
{
    public bool IsAiming => _isAiming;
    [SerializeField] private Transform _aimTarget;
    [SerializeField] private Rig _rig;
    [SerializeField] private LayerMask _layerMask;
   private Camera _mainCamera;
    private bool _isAiming;

    private void Awake()
    {
        _mainCamera=Camera.main;
       SetAimingState(false);
    }

    public void SetAimingState(bool isAiming)
    {
        _rig.weight = isAiming?1:0;
        _isAiming = isAiming;
    }
    private void Update()
    {
        if (!_isAiming)
        {
            return;
        }
       var ray= _mainCamera.ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out var hitInfo, 100, _layerMask))
       {
           _aimTarget.position = hitInfo.point;
       }
    }
}
