using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon/Create new ranged weapon")]
public class RangedWeaponData : WeaponData
{
    
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField][Range(0.01f, 1)] private float _rateOfFire;
    [SerializeField][Range(0,2)] private float _scatter;
    [SerializeField][Range(1, 50)] private int _range;

    public Bullet BulletTemplate => _bulletTemplate;
    public float RateOfFire => _rateOfFire;
    public float Scatter => _scatter;
    public int Range => _range;
}
