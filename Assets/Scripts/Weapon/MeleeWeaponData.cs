using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon/Create new melee weapon")]
public class MeleeWeaponData : WeaponData
{
    [SerializeField] private int _damage;
    [SerializeField] [Range(0.1f, 1)] private float _attackSpeed;

    public int Damage => _damage;
    public float AttackSpeed => _attackSpeed;
}
