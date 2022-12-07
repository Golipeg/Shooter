using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private BulletsCounter _bulletsCounter;
    public event Action OnShoot;
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _weapon.Shoot();
            OnShoot?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            _bulletsCounter.Recharge();
        }
    }
}
