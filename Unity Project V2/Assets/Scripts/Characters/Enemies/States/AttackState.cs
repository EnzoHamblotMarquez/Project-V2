using UnityEngine;

public class AttackState : EnemyState
{
    private GameObject player;
    private Stats playerStats;

    private float timer;

    public override void Enter()
    {
        base.Enter();
        player = GameObject.FindWithTag(PlayerController.playerTag);
        playerStats = player.GetComponent<Stats>();

        enemyStats = GetComponent<Stats>();
    }

    public override void Do()
    {
        base.Do();
        enemyRigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;

        if (timer > 1)
        {
            playerStats.TakeDamage(enemyStats.GetBaseDamage());
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    public override void Exit()
    {
        enemyRigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
