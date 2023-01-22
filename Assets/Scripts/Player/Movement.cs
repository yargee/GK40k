using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private NavMeshAgent _agent;

    private void Awake()
    {
       // _agent = GetComponent<NavMeshAgent>();
       // _agent.updateRotation = false;
        //_agent.updateUpAxis = false;
        //_agent.updatePosition = false;
    }

    private void FixedUpdate()
    {
        KeyboardMovement();
    }

    private void KeyboardMovement()
    {
        
        /*

        var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        _agent.destination = transform.position + direction;*/

        _rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _speed;
    }
}
