using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public WanderState wanderState;
    public ChaseState chaseState;
    public AttackState attackState;
    public ResetState resetState;

    bool goBack = false;
    bool isPlayerInRadius = false;

    EnemyState currentState;
    bool exitCurrentState = false;


    protected GameObject player;
    public Vector3 playerPosition { get; private set; }

    private void SelectState()
    {
        if (isPlayerInRadius && !goBack)
        {
            currentState = chaseState;

            if ((playerPosition - transform.position).magnitude < 1.3)
            {
                currentState = attackState;
            }

            if (!isPlayerInRadius)
            {
                currentState = wanderState;
            }

        }
        else
        {
            if (goBack)
            {
                currentState = resetState;

                if (resetState.time < 2)
                {
                    goBack = false;
                }
            }
            else
            {
                currentState = wanderState;
            }
        }

        currentState.Enter();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        wanderState = GetComponent<WanderState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();
        resetState = GetComponent<ResetState>();

        currentState = wanderState;
    }

    private void Update()
    {
        playerPosition = player.transform.position;
        isPlayerInRadius = (playerPosition - transform.position).magnitude < 10;

        SelectState();
        currentState.Do();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RoomTrigger"))
        {
            resetState.direction = transform.position - collision.gameObject.transform.position;
            goBack = true;
        }

    }

}
