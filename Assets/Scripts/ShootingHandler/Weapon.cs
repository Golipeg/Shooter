using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private ParticleSystem _muzzleEffect;
    [SerializeField] BulletsCounter _bulletsCounter;
    private bool _isEmptyAmmo = false;

    public void Shoot()
    {
        if (!_isEmptyAmmo)
        {
            var bullet = Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
            bullet.Initialize(_muzzle.forward);
            _muzzleEffect.Play();
        }
    }
    private void OnEnable()
    {
        _bulletsCounter.OnEmptyAmmo += CheckRestAmmo;
    }

    private void OnDisable()
    {
        _bulletsCounter.OnEmptyAmmo -= CheckRestAmmo;
    }

    private void CheckRestAmmo(bool isEmpty)
    {
        _isEmptyAmmo = isEmpty;
    }
}