using System.Collections;
using UnityEngine;

public class WanderState : EnemyState
{
    private bool timeToChangeDirection;


    public override void Enter()
    {
        base.Enter();

        timeToChangeDirection = true;
    }

    public override void Do()
    {
        base.Do();

        if (timeToChangeDirection)
        {
            enemyRigidBody2D.velocity = ChooseDirection() * baseEnemySpeed / 4;
            StartCoroutine(ChangeDirectionCooldown());
        }

    }

    Vector3 ChooseDirection()
    {
        int selector;

        selector = Random.Range(0, 7);

        switch (selector)
        {
            case 0: return Vector3.left;
            case 1: return Vector3.down;
            case 2: return Vector3.right;
            case 3: return Vector3.up;

            default: return Vector3.zero;
        }
    }

    IEnumerator ChangeDirectionCooldown()
    {
        timeToChangeDirection = false;

        yield return new WaitForSeconds(1);

        timeToChangeDirection = true;
    }

}
