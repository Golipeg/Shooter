using System;
using Unity.VisualScripting;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public  event Action Died;
    public bool IsAlive => _currentHealth > 0;

    [SerializeField] private float _startHealth = 100f;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _startHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!IsAlive)
        {
            return;
        }
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            
            Died?.Invoke();
            
        }
    }
}