using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    public bool isComplete { get; protected set; }

    public float startTime {  get; protected set; } 
    public float time => Time.time - startTime;

    protected Rigidbody2D enemyRigidBody2D;
    protected Collider2D enemyCollider2D;

    protected Stats enemyStats;
    public float baseEnemySpeed {  get; protected set; }
    protected Vector3 currentMovement;


    public virtual void Initialize()
    {
    }

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

    public virtual void Do()
    {

    }

    public virtual void Exit() { }
}
