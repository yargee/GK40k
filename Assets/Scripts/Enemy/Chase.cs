using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField] private Health _target;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationOffset;

    private void FixedUpdate()
    {
        _rigidbody.velocity = GetDirection() * _speed;
        Rotate();
    }

    private Vector2 GetDirection()
    {
        return _target.transform.position - transform.position;
    }

    private void Rotate()
    {
        var direction = (_target.transform.position - transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - _rotationOffset, Vector3.forward);
    }
}
