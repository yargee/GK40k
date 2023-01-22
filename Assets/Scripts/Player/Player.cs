using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Shooting _shootting;
    [SerializeField] private Inventory _equipment;

    public void ChangeWeapon(Constants.Equipment id)
    {
        var weapon = _equipment.GetRangedWeapon(id);
        _shootting.SetWeapon(weapon);

        Debug.Log($"weapon changed to {weapon.name}.");
    }

}
