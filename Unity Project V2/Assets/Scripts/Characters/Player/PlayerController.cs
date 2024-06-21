using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 currentInputedDirection;
    private Rigidbody2D playerRigidbody2D;

    public float baseSpeed { get; private set; }
    private float currentSpeed;

    private PlayerDash dashManager;

    private Stats playerStats;
    private PlayerAttack playerAttack;

    public const string playerTag = "Player";

    private const string dashInput = "Jump";
    private const string attackInput = "Fire1";


    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();

        dashManager = GetComponent<PlayerDash>();

        playerStats = GetComponent<Stats>();
        playerAttack = GetComponent<PlayerAttack>();

        baseSpeed = playerStats.baseSpeed;

        currentSpeed = baseSpeed;
    }


    private void Update()
    {
        //Take input
        currentInputedDirection = Vector2.right * Input.GetAxisRaw("Horizontal") + Vector2.up * Input.GetAxisRaw("Vertical");
        currentInputedDirection.Normalize();

        if (Input.GetAxis(dashInput) > 0)
        {
            dashManager.Dash();
        }

        //Move player's Rigidbody2D
        playerRigidbody2D.velocity = currentInputedDirection * currentSpeed;


        //Player's Base Attack Input
        if (Input.GetAxis(attackInput) > 0)
        {
            playerAttack.BaseAttack(playerStats.GetBaseDamage());
        }
    }

    public void SetCurrentSpeed(float currentSpeed)
    {
        this.currentSpeed = currentSpeed;
    }
}