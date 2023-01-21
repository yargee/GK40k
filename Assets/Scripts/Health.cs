using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    public event UnityAction Died;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    public void TakeDamage(int damage)
    {
        if (damage <= 0) return;

        _currentHealth = _currentHealth - damage;

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }

    public void GetHeal(int heal)
    {
        if (heal <= 0) return;

        _currentHealth = _currentHealth + heal > _maxHealth ? _maxHealth : _currentHealth + heal;
    }

    public void SetHealth(int health)
    {
        _maxHealth = health;
        _currentHealth = health;
    }
}
