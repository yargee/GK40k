using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using UnityEngine;

public class Attack : Action
{
    [SerializeField] private int _damage;
    [SerializeField] private SharedPlayer _target;
    [SerializeField] private float _attackSpeed;

    private bool _attacking = false;

    public override TaskStatus OnUpdate()
    {
        if(_attacking)
        {
            return TaskStatus.Running;
        }
        else
        {
            StartCoroutine(AttackAction());
            return TaskStatus.Success;
        }
    }

    private IEnumerator AttackAction()
    {
        _attacking = true;
        _target.Value.TakeDamage(_damage);

        yield return new WaitForSeconds(_attackSpeed);

        _attacking = false;
    }
}
