using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SharedPlayer : SharedVariable<Player>
{
    public static implicit operator SharedPlayer(Player value) { return new SharedPlayer { Value = value }; }
}
