using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private BehaviorTree _behaviourTree;
    [SerializeField] private Health _health;
    [SerializeField] private Player _target;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }
    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    public virtual void Init(Player target)
    {
        _target = target;
        var player = _behaviourTree.GetVariable("_player");
        player.SetValue(target);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnDied()
    {
        _collider.enabled = false;
        _health.enabled = false;

        Destroy(gameObject);
    }
}
