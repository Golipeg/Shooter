 
using System;
using UnityEngine;

public class PlayerRotationHandler : MonoBehaviour
{
    [SerializeField] private float _horizontalRotationSpeed;
    private void Update()
    {
       var horizontalRotation= Input.GetAxis("Mouse X")*_horizontalRotationSpeed*Time.deltaTime;
       
        transform.Rotate(0,horizontalRotation,0);
    }
}
