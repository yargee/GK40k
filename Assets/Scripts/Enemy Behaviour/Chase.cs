using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Chase : Action
{
    [SerializeField] private SharedPlayer _target;
    [SerializeField] private float _rotationOffset;
    [SerializeField] private SharedInt _sqrAttackDistance;

    public SharedInt _maxSightDistance;

    private NavMeshAgent _agent;

    public override void OnAwake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public override TaskStatus OnUpdate()
    {
        _agent.SetDestination(_target.Value.transform.position);
        Rotate();

        if (IsTargetLost())
        {
            _agent.isStopped = true;
            return TaskStatus.Failure;
        }

        if(IsAttackDistance())
        {
            _agent.isStopped = true;
            return TaskStatus.Success;
        }

        _agent.isStopped = false;

        return TaskStatus.Running;
    }

    private Vector2 GetDirection()
    {
        return (_target.Value.transform.position - transform.position).normalized;
    }

    private void Rotate()
    {
        var direction = GetDirection();
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - _rotationOffset, Vector3.forward);
    }

    private bool IsAttackDistance()
    {
        return _sqrAttackDistance.Value >= Vector2.SqrMagnitude(transform.position - _target.Value.transform.position);
    }

    private bool IsTargetLost()
    {
        return _maxSightDistance.Value <= Vector2.SqrMagnitude(transform.position - _target.Value.transform.position);
    }
}
