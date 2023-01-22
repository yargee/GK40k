using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private Vector2 _position;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        SetTargetPostition();
        MoveToPosition();
    }

    public void SetTargetPostition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void MoveToPosition()
    {
        _agent.destination = _position;
    }
}
