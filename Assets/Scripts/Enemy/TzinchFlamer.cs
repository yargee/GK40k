using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TzinchFlamer : Enemy
{
    [SerializeField] private EnemyShooting _shooting;

    public override void Init(Player target)
    {
        base.Init(target);
        _shooting.Init(target);
    }
}
