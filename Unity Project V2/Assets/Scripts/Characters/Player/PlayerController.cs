using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 currentInputedDirection;
    private Rigidbody2D playerRigidbody2D;

    [SerializeField]
    private float baseSpeed;
    private float currentSpeed;

    private DashManager dashManager;


    private void Start()
    {
        currentSpeed = baseSpeed;

        playerRigidbody2D = GetComponent<Rigidbody2D>();

        dashManager = GetComponent<DashManager>();
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
    }


    public float GetBaseSpeed()
    {
        return baseSpeed;
    }

    public float GetCurrentSpeed() //May be unnecessary !!
    {
        return currentSpeed;
    }

    public void SetCurrentSpeed(float currentSpeed)
    {
        this.currentSpeed = currentSpeed;
    }
}