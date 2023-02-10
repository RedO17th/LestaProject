using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : BasePlayerContoller
{
    [SerializeField] private Animator _animator = null;

    [Space]
    [SerializeField] private string _movementParameter = "MovementSpeed";

    private MovementController _movementController = null; 

    public override void Initialize(BasePlayer player)
    {
        base.Initialize(player);
    }

    public override void Prepare()
    {
        _movementController = _player.GetControllerBy<MovementController>();
    }

    private void Update()
    {
        PlayMoveByNormalizedSpeed();
    }

    private void PlayMoveByNormalizedSpeed()
    {
        _animator.SetFloat(_movementParameter, _movementController.NormalizedMovementSpeed);
    }
}
