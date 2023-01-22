using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private MeleeWeaponData _data;
    [SerializeField] private MeleeWeaponTemplate _template;

    private WaitForSeconds _delay;

    public bool Attacking { get; private set; } = false;
    public MeleeWeaponData Data => _data;

    public void Init()
    {
        _delay = new WaitForSeconds(_data.AttackSpeed);
        _template.Disable();
        _template.Init(_data.Damage);
    }

    public IEnumerator Attack()
    {
        Attacking = true;
        _template.Activate();
        _template.Attack();
        yield return _delay;
        _template.Disable();
        Attacking = false;
    }
}
