using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Shooting _shootting;
    [SerializeField] private Inventory _equipment;
    [SerializeField] private Health _health;

    public event UnityAction<int> HitTaken;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }
    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        Destroy(gameObject);
    }

    public void ChangeWeapon(Constants.Equipment id)
    {
        var weapon = _equipment.GetRangedWeapon(id);
        _shootting.SetWeapon(weapon);

        Debug.Log($"weapon changed to {weapon.name}.");
    }

    public void TakeDamage(int damage)
    {
        //damage reduce by armor 
        _health.TakeDamage(damage);
        HitTaken?.Invoke(damage);
    }
}
