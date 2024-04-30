using System.Collections;
using UnityEngine;

public class DashManager : MonoBehaviour
{
    [SerializeField] private float dashSpeedBoostPercentage;
    private float dashSpeed;
    [SerializeField] private float dashDuration;

    [SerializeField] private float dashTotalCooldown; //Needs to be higher than "dashDuration"
    private float dashCurrentCooldown;
    private bool dashInCooldown;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();

        dashSpeed = playerController.GetBaseSpeed() * (1 + dashSpeedBoostPercentage / 100); 

        dashInCooldown = false;
    }

    // Update is called once per frame
    public void Dash()
    {
        if (!dashInCooldown)
        {
            StartCoroutine(Dashing());
        }
    }

    private void Update ()
    {
        dashCurrentCooldown -= Time.deltaTime;

        if (dashCurrentCooldown <= 0)
        {
            dashInCooldown = false;
        }
    }

    IEnumerator Dashing() //Dash shoud make you advance a certain distance, not just boost your "currentSpeed" !!
    {
        dashInCooldown = true;
        dashCurrentCooldown = dashTotalCooldown;

        playerController.SetCurrentSpeed(dashSpeed);

        yield return new WaitForSeconds(dashDuration);

        playerController.SetCurrentSpeed(playerController.GetBaseSpeed());
    }

}
