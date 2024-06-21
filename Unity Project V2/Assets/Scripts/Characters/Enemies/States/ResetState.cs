using UnityEngine;

public class ResetState : EnemyState
{
    private Vector3 direction;

    public const string roomExitCollidersContainer = "RoomExitColliders";


    public override void Enter()
    {
        base.Enter();
        direction = transform.position - GameObject.Find(roomExitCollidersContainer).transform.position;
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
