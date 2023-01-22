using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MeleeCombat : MonoBehaviour
{
    [SerializeField] private MeleeWeapon _meleeWeapon;

    private EventSystem _eventSystem;

    private void Awake()
    {
        _eventSystem = EventSystem.current;
        _meleeWeapon.Init();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && !_eventSystem.IsPointerOverGameObject())
        {
            if (_meleeWeapon.Attacking) return;
            
            StartCoroutine(_meleeWeapon.Attack());
        }
    }
}
