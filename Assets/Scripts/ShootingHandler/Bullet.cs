using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed=10f;
    [SerializeField] private int _damage = 50;
    [SerializeField] private float _lifeTime = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 direction)
    {
        _rigidbody.velocity = direction * _speed;
        Destroy(gameObject,_lifeTime);
    }

    public void OnCollisionEnter(Collision other)
    {
        var otherHealth=other.gameObject.GetComponent<HealthHandler>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(_damage);
        }

        var effectHandler = other.gameObject.GetComponent<EffectHandler>();
        if (effectHandler != null)
        {
            for (int i = 0; i < other.contactCount; i++)
            {
                var contactPoint = other.contacts[i];
                effectHandler.ShowHitEffect(contactPoint.point,contactPoint.normal);
            }
            
        }
        Destroy(gameObject);
    }
}
