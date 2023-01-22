using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponTemplate : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _collider;

    private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
    }

    public void Init(int damage)
    {
        _damage = damage;
    }

    public void Attack()
    {
        _animator.SetTrigger(Constants.ATTACK);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        //_collider.enabled = true;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        //_collider.enabled = false;
    }
}
