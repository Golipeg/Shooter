using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private ParticleSystem _muzzleEffect;
    public void Shoot()
    {
        var bullet =Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
        bullet.Initialize(_muzzle.forward);
    }
}
