using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovementNavMesh : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private EventSystem _eventSystem;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _navMeshAgent.speed = 0;
        _eventSystem = EventSystem.current;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                if (_eventSystem.IsPointerOverGameObject())
                    return;
                
                _navMeshAgent.SetDestination(hit.point);
            }
        }
    }

    private void FixedUpdate()
    {
        var targetSpeed = Input.GetKey(KeyCode.LeftShift) ? 7f : 3.5f;
        _navMeshAgent.speed = Mathf.Lerp(_navMeshAgent.speed, targetSpeed, 3f * Time.deltaTime);
        
        if (_navMeshAgent.remainingDistance < 0.01f)
            _navMeshAgent.speed = 0;

        _animator.SetFloat("Speed", _navMeshAgent.speed);
    }
}
