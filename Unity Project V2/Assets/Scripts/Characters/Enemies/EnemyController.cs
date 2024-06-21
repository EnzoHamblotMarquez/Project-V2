using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public WanderState wanderState;
    public ChaseState chaseState;
    public AttackState attackState;
    public ResetState resetState;

    private bool goBack = false;
    private bool isPlayerInRadius = false;

    private EnemyState currentState;
    private EnemyState oldState;


    protected GameObject player;
    public Vector3 playerPosition { get; private set; }

    public const string enemyTag = "Enemy";


    private void SelectState()
    {
        if (isPlayerInRadius)
        {
            if (!goBack)
            {
                currentState = chaseState;

                if ((playerPosition - transform.position).magnitude < 1.3)
                {
                    currentState = attackState;
                }
            }
            else
            {
                currentState = resetState;

                if (resetState.isComplete)
                {
                    goBack = false;
                }
            }

        }
        else
        {
            if (goBack)
            {
                currentState = resetState;

                if (resetState.isComplete)
                {
                    goBack = false;
                }
            }
            else
            {
                currentState = wanderState;
            }
        }

        if (oldState != currentState)
        {
            oldState.Exit();
            currentState.Enter();
            oldState = currentState;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        wanderState = GetComponent<WanderState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();
        resetState = GetComponent<ResetState>();

        currentState = wanderState;
        oldState = resetState;
    }

    private void Update()
    {
        playerPosition = player.transform.position;
        isPlayerInRadius = (playerPosition - transform.position).magnitude < 5;

        SelectState();
        currentState.Do();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            goBack = true;
        }

    }

}
