using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private List<RangedWeapon> _weapons;

    public RangedWeapon GetWeapon(int id)
    {
        return _weapons.FirstOrDefault(x => x.Data.Id == id);
    }
}
