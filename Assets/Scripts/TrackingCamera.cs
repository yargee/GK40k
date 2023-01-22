using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] private Transform _anchor;
    [SerializeField] private float _moveSpeed;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _anchor.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _anchor.position + _offset, _moveSpeed * Time.fixedDeltaTime);
    }
}