using System.Collections;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField] private RangedWeaponData _data;
    
    private Transform _barrel;
    private WaitForSeconds _delay;

    public bool Shooting { get; private set; }
    public RangedWeaponData Data => _data;

    public void Init(Transform barrel)
    {
        Debug.Log("Init weapon");

        _barrel = barrel;
        Shooting = false;
        _delay = new WaitForSeconds(_data.RateOfFire);
    }

    private Vector2 CalculateScatter()
    {
        return new Vector2(Random.Range(-_data.Scatter, _data.Scatter), Random.Range(-_data.Scatter, _data.Scatter));
    }

    private float CalculateRange()
    {
        return _data.Range + Random.Range(-_data.Scatter, _data.Scatter);
    }

    public IEnumerator Shoot(Vector2 target)
    {
        Shooting = true;
        var bullet = Instantiate(_data.BulletTemplate, _barrel);
        _barrel.DetachChildren();
        bullet.Init((target - CalculateScatter()).normalized, CalculateRange());
        yield return _delay;
        Shooting = false;
    }
}
