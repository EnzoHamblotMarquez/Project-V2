using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void Do()
    {
        base.Do();
        currentMovement = (playerPosition - transform.position).normalized * baseEnemySpeed;
        enemyRigidBody2D.velocity = currentMovement;
    }

    public override void Exit()
    {

    }
}
