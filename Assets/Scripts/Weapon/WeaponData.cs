using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon/Create new weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _id;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField][Range(0.1f, 1)] private float _rateOfFire;
    [SerializeField][Range(0,1)] private float _scatter;
    [SerializeField][Range(10, 50)] private int _range;

    public string Name => _name;
    public int Id=> _id;
    public Bullet BulletTemplate => _bulletTemplate;
    public float RateOfFire => _rateOfFire;
    public float Scatter => _scatter;
    public int Range => _range;
}
