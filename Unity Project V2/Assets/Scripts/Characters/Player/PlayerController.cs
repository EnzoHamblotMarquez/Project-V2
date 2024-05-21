using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 currentInputedDirection;
    private Rigidbody2D playerRigidbody2D;

    public float baseSpeed { get; private set; }
    private float currentSpeed;

    private DashManager dashManager;

    private Stats playerStats;
    private PlayerAttack playerAttack;


    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();

        dashManager = GetComponent<DashManager>();

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

        if (Input.GetAxis("Jump") > 0)
        {
            dashManager.Dash();
        }
        
        //Move player's Rigidbody2D
        playerRigidbody2D.velocity = currentInputedDirection * currentSpeed;


        if (Input.GetAxis("Fire1") > 0)
        {
            playerAttack.BaseAttack(playerStats.baseDamage);
        }
    }

    public void SetCurrentSpeed(float currentSpeed)
    {
        this.currentSpeed = currentSpeed;
    }
}