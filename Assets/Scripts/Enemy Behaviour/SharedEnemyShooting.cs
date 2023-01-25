using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SharedEnemyShooting : SharedVariable<EnemyShooting>
{
    public static implicit operator SharedEnemyShooting(EnemyShooting value) { return new SharedEnemyShooting { Value = value }; }
}
