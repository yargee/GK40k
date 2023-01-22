using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<RangedWeapon> _rangedWeapons;
    [SerializeField] private List<MeleeWeapon> _meleeWeapons;

    public RangedWeapon GetRangedWeapon(Constants.Equipment id)
    {
        return _rangedWeapons.FirstOrDefault(x => x.Data.Id == id);
    }
}
