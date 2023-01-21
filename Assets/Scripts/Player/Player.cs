using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Shooting _shootting;
    [SerializeField] private Equipment _equipment;

    public void ChangeWeapon(int id)
    {
        var weapon = _equipment.GetWeapon(id);
        _shootting.SetWeapon(weapon);

        Debug.Log($"weapon changed to {weapon.name}.");
    }

}
