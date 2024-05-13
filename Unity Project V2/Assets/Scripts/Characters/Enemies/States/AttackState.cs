using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void Do()
    {
        enemyRigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public override void Exit()
    {
        ///enemyRigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
