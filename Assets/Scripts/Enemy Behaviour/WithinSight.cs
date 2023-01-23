using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class WithinSight : Conditional
{
    [SerializeField] private SharedPlayer _target;
    [SerializeField] private SharedInt _maxSightDistance;

    public override TaskStatus OnUpdate()
    {
        return TargetNear() ? TaskStatus.Success : TaskStatus.Running;
    }

    private bool TargetNear()
    {
        return _maxSightDistance.Value >= Vector2.SqrMagnitude(_target.Value.transform.position - transform.position);
    }
}
