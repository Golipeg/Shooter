using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    public event Action Died;
    public bool IsAlive => _currentHealth > 0;
    [SerializeField] private float _startHealth = 100f;
    [SerializeField] private HealthBar _healthBar;
    private float _currentHealth;
    

    private void Start()
    {
        _currentHealth = _startHealth;
        _healthBar.SetMaxHealth(_startHealth);

    }

    public void TakeDamage(int damage)
    {
        if (!IsAlive)
        {
            return;
        }
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }
}