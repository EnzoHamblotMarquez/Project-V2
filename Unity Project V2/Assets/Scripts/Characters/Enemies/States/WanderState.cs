using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void Do()
    { 
        enemyRigidBody2D.velocity = Vector3.up * baseEnemySpeed;

        if (time > 2)
        {
            enemyRigidBody2D.velocity = Vector3.right * baseEnemySpeed;
        }
        if (time > 4)
        {
            enemyRigidBody2D.velocity = Vector3.down * baseEnemySpeed;
        }
        if (time > 6)
        {
            enemyRigidBody2D.velocity = Vector3.left * baseEnemySpeed;
        }
    }

    public override void Exit() 
    {

    }
}
