using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponTemplate : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _attackPoint;
    [SerializeField][Range(0.1f,1)] private float _attackArea;
    [SerializeField] private LayerMask _layer;

    private int _damage;

    public void Init(int damage)
    {
        _damage = damage;
    }

    public void Attack()
    {
        _animator.SetTrigger(Constants.ATTACK);

        var enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackArea, _layer);

        Debug.Log("ENEMIES HIT " + enemies.Length);

        foreach(var enemy in enemies)
        {
            if(enemy.TryGetComponent(out Enemy target))
            {
                target.TakeDamage(_damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackArea);
    }
}
