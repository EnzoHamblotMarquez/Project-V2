using UnityEngine;

public class ChaseState : EnemyState
{

    protected GameObject player;
    public Vector3 playerCurrentPosition { get; private set; }


    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindWithTag(PlayerController.playerTag);
    }

    public override void Do()
    {
        base.Do();
        currentMovement = (playerCurrentPosition - transform.position).normalized * baseEnemySpeed;
        enemyRigidBody2D.velocity = currentMovement;

        playerCurrentPosition = player.transform.position;
    }

}
