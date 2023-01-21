using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Chase))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Health _health;
    [SerializeField] private Chase _chase;

    private Health _target;

    private void OnEnable()
    {        
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _chase = GetComponent<Chase>();

        _health.Died += OnDied;
    }
    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    public void Init(Health target)
    {
        _target = target;
        _chase.Init(target);
    }

    private void OnDied()
    {
        _collider.enabled = false;
        _rigidbody.simulated = false;
        _health.enabled = false;
        _chase.enabled = false;

        Destroy(gameObject);
    }
}
