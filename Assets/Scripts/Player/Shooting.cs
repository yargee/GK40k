using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    [SerializeField] private RangedWeapon _rangedWeapon;
    [SerializeField] private Transform _barrel;

    private Camera _camera;
    private EventSystem _eventSystem;

    private void Awake()
    {
        _camera = Camera.main;
        _eventSystem = EventSystem.current;
        _rangedWeapon.Init(_barrel);
    }

    private void Update()
    {        
        if(Input.GetMouseButton(0) && !_eventSystem.IsPointerOverGameObject())
        {
            if (_rangedWeapon.Shooting) return;

            Vector2 target = _camera.ScreenToWorldPoint(Input.mousePosition) - _barrel.position;
            StartCoroutine(_rangedWeapon.Shoot(target));
        }
    }

    public void SetWeapon(RangedWeapon weapon)
    {
        if(weapon == null)
        {
            Debug.LogError("Weapon is null");
            return;
        }

        _rangedWeapon = weapon;
        _rangedWeapon.Init(_barrel);
    }
}
