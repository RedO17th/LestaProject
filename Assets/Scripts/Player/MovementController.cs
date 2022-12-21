using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MovementController : BasePlayerContoller
{
    //Test
    public Animator a;

     //TODO: Transfer to Settings system
    [Range(5f, 25f)]
    [SerializeField] private float _speedMovement = 5f;
    [Range(5f, 50f)]
    [SerializeField] private float _speedRotation = 5f;
    //..

    public event Action OnPlayerMove;

    private BaseInputOfMovement _input = null;
    private Vector3 _direction = Vector3.zero;

    public override void Initialize(BasePlayer player)
    {
        base.Initialize(player);

        _input = GetComponent<BaseInputOfMovement>();
    }

    void Update()
    {
        if (IsEnabled)
        {
            CalculateMovement();
            CalcuateRotation();
        }
    }

    private void CalculateMovement()
    {



        if (Input.GetKey(KeyCode.W))
        {
            a.SetBool("Walk", true);
        }
        else
        { 
            a.SetBool("Walk", false);
        }



        //_direction = _input.Read();
        //_player.Move(_direction * _speedMovement * Time.deltaTime);
    }

    private void CalcuateRotation()
    {
        var directionRotation = new Vector3(_direction.x, 0f, _direction.z);
        if (directionRotation.magnitude != 0f)
        {
            var rotation = Quaternion.LookRotation(directionRotation);
            var targetRotation = Quaternion.Slerp(_player.Rotation, rotation, Time.deltaTime * _speedRotation);

            _player.Rotate(targetRotation);
        }
    }
}
