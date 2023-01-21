using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private RangedWeapon _rangedWeapon;
    [SerializeField] private Transform _barrel;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _rangedWeapon.Init(_barrel);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (_rangedWeapon.Shooting) return;

            Vector2 target = _camera.ScreenToWorldPoint(Input.mousePosition) - _barrel.position;
            StartCoroutine(_rangedWeapon.Shoot(target));
        }
    }

    public void SetWeapon(RangedWeapon weapon)
    {
        _rangedWeapon = weapon;
    }
}
