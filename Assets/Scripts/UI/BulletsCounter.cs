using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class BulletsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bulletsQuantity;
    private const int START_BULLET_QUANTITY=20;
    private int _currentBulletQuantity;
    [SerializeField] private PlayerWeaponHandler _playerWeaponHandler;
    public event Action<bool> OnEmptyAmmo; 
    private void Start()
    {
        _bulletsQuantity.text = START_BULLET_QUANTITY.ToString();
        _currentBulletQuantity = START_BULLET_QUANTITY;
        _playerWeaponHandler.OnShoot += DecreaseBullets;

    }

    private void OnDisable()
    {
        _playerWeaponHandler.OnShoot -= DecreaseBullets;
    }

    private void DecreaseBullets()
    {
        if (_currentBulletQuantity > 0)
        {
            _currentBulletQuantity--;
            _bulletsQuantity.text = _currentBulletQuantity.ToString();
        }

        else if (_currentBulletQuantity <= 0)
        {
            Debug.Log("EmptyAmmo");
            OnEmptyAmmo?.Invoke(true);
        }
    }
    [UsedImplicitly]
    public void Recharge()
    { 
        _bulletsQuantity.text = START_BULLET_QUANTITY.ToString();
        _currentBulletQuantity = START_BULLET_QUANTITY;
        OnEmptyAmmo?.Invoke(false);
    }
}
