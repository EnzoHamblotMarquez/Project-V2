using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    public bool isComplete { get; protected set; }

    public float startTime { get; protected set; }
    public float time => Time.time - startTime;

    protected Rigidbody2D enemyRigidBody2D;
    protected Collider2D enemyCollider2D;

    protected Stats enemyStats;
    public float baseEnemySpeed { get; protected set; }
    protected Vector3 currentMovement;



    //Enter is called when entering a new state
    public virtual void Enter()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        enemyCollider2D = GetComponent<Collider2D>();

        enemyStats = GetComponent<Stats>();
        baseEnemySpeed = enemyStats.baseSpeed;

        enemyRigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        isComplete = false;
        startTime = Time.time;
    }

    //Do is called every frame
    public virtual void Do()
    {

    }

    //Exit is called before entering a new state
    public virtual void Exit() { }
}
