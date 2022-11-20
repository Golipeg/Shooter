
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimationHandler))]// скрипт PlayerMovementHandler нельзя будет повесить без скрипта PlayerAnimationHandler
public class PlayerMovementHandler : MonoBehaviour  
{
    private PlayerAnimationHandler _animationHandler;
    [SerializeField] private float _walkingSpeed;
    private void Awake()
    {
        _animationHandler = GetComponent<PlayerAnimationHandler>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");// A and D 
        var z = Input.GetAxis("Vertical");// W and S
        /* т.к x и z может принимать значение 1 или -1 , т.е. обьект будет двигаться или влево
         или вправо , вперёд назад*/
        var direction=(transform.right * x + transform.forward * z).normalized;
        var movementDelta=direction.normalized * _walkingSpeed * Time.deltaTime;
        var isWalking = Mathf.Abs(movementDelta.sqrMagnitude) > Mathf.Epsilon;// если длина вектора меньше Epsilon, то мы стоим 
        _animationHandler.SetWalkMode(isWalking);
        transform.Translate(movementDelta); 
        
    }
}
