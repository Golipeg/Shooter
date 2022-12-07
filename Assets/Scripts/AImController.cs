using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImController : MonoBehaviour
{
    [SerializeField] private Transform _aimTarget;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] Camera _mainCamera;

    private void Awake()
    {
        _mainCamera=Camera.main;
    }

    private void Update()
    {
       var ray= _mainCamera.ScreenPointToRay(Input.mousePosition);
       if (Physics.Raycast(ray, out var hitInfo, 100, _layerMask))
       {
           _aimTarget.position = hitInfo.point;
       }
    }
}
