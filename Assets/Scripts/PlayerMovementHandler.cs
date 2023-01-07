using System;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(
    typeof(AnimationHandler))] // скрипт PlayerMovementHandler нельзя будет повесить без скрипта PlayerAnimationHandler
public class PlayerMovementHandler : MonoBehaviour
{
    private AnimationHandler _animationHandler;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private Transform _camera;
    private bool _isAiming;

    private void Awake()
    {
        _animationHandler = GetComponent<AnimationHandler>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal"); // A and D 
        var z = Input.GetAxis("Vertical"); // W and S*/
        
        var currentWalkingSpeed = Mathf.Max(Mathf.Abs(x), Mathf.Abs(z)) * _walkingSpeed;
        var isWalking = currentWalkingSpeed > 0;
        _animationHandler.SetWalkMode(isWalking);
        
        if (!isWalking && !_isAiming)
        {
            return;
        }
        var deltaAngle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, _camera.rotation.eulerAngles.y + deltaAngle, 0);
        
            var movementDelta = Vector3.forward* currentWalkingSpeed * Time.deltaTime;
            transform.Translate(movementDelta, Space.Self);

    }

    public void SetAimingState(bool isAiming)
    {
        _isAiming = isAiming;
    }
}