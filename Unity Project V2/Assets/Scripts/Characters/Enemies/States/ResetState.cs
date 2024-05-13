using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetState : EnemyState
{
    internal Vector3 direction;


    public override void Enter()
    {
        base.Enter();
    }

    public override void Do()
    {
        currentMovement = direction.normalized * 2;
        enemyRigidBody2D.velocity = currentMovement;
    }
}
