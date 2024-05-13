using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    public bool isComplete { get; protected set; }

    protected float startTime;

    public float time => Time.time - startTime; //Returns the current running 

    protected Rigidbody2D enemyRigidBody2D;
    protected Collider2D enemyCollider2D;

    protected GameObject player;
    public Vector3 playerPosition { get; private set; }

    protected Stats enemyStats;
    public float baseEnemySpeed {  get; protected set; }
    protected Vector3 currentMovement;


    public virtual void Enter()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        enemyCollider2D = GetComponent<Collider2D>();
        player = GameObject.FindWithTag("Player");

        enemyStats = GetComponent<Stats>();
        baseEnemySpeed = enemyStats.baseSpeed;

        enemyRigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        startTime = Time.time;
    }

    public virtual void Do()
    {
        playerPosition = player.transform.position;
    }

    public virtual void FixedDo() { }

    public virtual void Exit() { }
}
