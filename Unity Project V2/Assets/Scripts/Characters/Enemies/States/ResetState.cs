using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetState : EnemyState
{
    internal Vector3 direction;


    public override void Enter()
    {
        base.Enter();
        direction = transform.position - GameObject.Find("RoomTriggers").transform.position;
    }

    public override void Do()
    {
        currentMovement = direction.normalized * 2;
        enemyRigidBody2D.velocity = currentMovement;

        if (time > 1)
        {
            isComplete = true;
        }
    }
}
