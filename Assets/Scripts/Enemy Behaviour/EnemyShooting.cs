using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private int _range;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _barrel;
    [SerializeField] private Bullet _bullet;

    [SerializeField] private Player _target;
    public bool Shooting { get; private set; }
    public Transform Barrel => _barrel;

    public void Init(Player target)
    {
        Shooting = false;
        _target = target;
    }

    public IEnumerator Shoot()
    {
        Shooting = true;
        var bullet = Instantiate(_bullet, _barrel);
        _barrel.DetachChildren();

        bullet.Init((_target.transform.position - _barrel.position).normalized, _range);

        yield return new WaitForSeconds(_speed);

        Shooting = false;
    }
}
