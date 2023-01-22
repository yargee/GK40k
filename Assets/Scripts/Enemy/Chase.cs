using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    [SerializeField] private Health _target;
   // [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _rotationOffset;

    private NavMeshAgent _agent;

    private void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {

        _agent.SetDestination(_target.transform.position);
        //_rigidbody.velocity = GetDirection() * _speed;
        Rotate();
    }

    private Vector2 GetDirection()
    {
        return (_target.transform.position - transform.position).normalized;
    }

    private void Rotate()
    {
        var direction = GetDirection();
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - _rotationOffset, Vector3.forward);
    }
    public void Init(Health target)
    {
        _target = target;
    }
}
