using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    [SerializeField] private Constants.Equipment _id;

    public Constants.Equipment Id => _id;
}
