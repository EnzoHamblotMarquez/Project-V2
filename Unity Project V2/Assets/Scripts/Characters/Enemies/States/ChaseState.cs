using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{

    protected GameObject player;
    public Vector3 playerPosition { get; private set; }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindWithTag("Player");
    }

    public override void Do()
    {
        base.Do();
        currentMovement = (playerPosition - transform.position).normalized * baseEnemySpeed;
        enemyRigidBody2D.velocity = currentMovement;
        
        playerPosition = player.transform.position;
    }

}
