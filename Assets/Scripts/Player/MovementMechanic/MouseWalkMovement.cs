using UnityEngine;

public class MouseWalkMovement : BaseMovementMechanic
{
    private Vector3 _targetPoint = Vector3.zero;

    public override void Initialize(BasePlayerContoller controller)
    {
        base.Initialize(controller);

        _input = controller.GetComponent<MouseInputOfMovement>();
    }

    public override void Move()
    {
        var point = _input.Read();

        if (_targetPoint != point)
        {
            if (_navMeshAgent.isStopped)
                _navMeshAgent.isStopped = false;

            _targetPoint = point;

            _navMeshAgent.SetDestination(_targetPoint);
        }
    }

    public override void Rotate() { }

    public override void Stop()
    {
        _navMeshAgent.isStopped = true;
    }
}
