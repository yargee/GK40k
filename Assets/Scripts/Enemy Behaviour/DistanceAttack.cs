using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class DistanceAttack : Action
{
    [SerializeField] private SharedLayerMask _layers;
    [SerializeField] private SharedEnemyShooting _shooting;
    [SerializeField] private SharedPlayer _target;
    [SerializeField] private SharedTransform _attackPoint;

    private Vector2 _direction;

    public override TaskStatus OnUpdate()
    {
        _direction = (_target.Value.transform.position - _shooting.Value.Barrel.position).normalized;

        if (_shooting.Value.Shooting)
        {
            return TaskStatus.Failure;
        }
        else if(TargetInLoS())
        {
            StartCoroutine(_shooting.Value.Shoot());
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

    private bool TargetInLoS()
    {
        RaycastHit2D[] result = Physics2D.RaycastAll(_attackPoint.Value.position, _direction, Mathf.Infinity, _layers.Value);
        
        for(int i = 0; i < result.Length; i++)
        {
            Debug.Log(result[i].collider.gameObject.name);

            if (result[i].collider.TryGetComponent(out Player player) && i > 0)
            {
                return false;
            }
        }

        Debug.Log("--------------------");
        return true;
    }
}
