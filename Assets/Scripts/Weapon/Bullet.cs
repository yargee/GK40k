using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private int _damage;
    [SerializeField][Range(0,100)] private int _armorPiercing;
    [SerializeField] private float _speed;

    private Vector2 _target;
    private float _lifetime;

    private void Update()
    {
        if (_target == null) return;

        Fly();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Health enemy))
        {
            enemy.TakeDamage(_damage);

            bool pierce = Random.Range(0, 101) < _armorPiercing;

            if(!pierce)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Init(Vector2 target, float range)
    {
        _target = target;
        _lifetime = range/_speed;
    }

    private void Fly()
    {
        _rigidbody.velocity = _target * _speed;
        StartCoroutine(DelayedDestroy());  //change to pool
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(_lifetime);
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
