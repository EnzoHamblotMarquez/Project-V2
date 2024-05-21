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

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        ///dashSpeed = playerController.baseSpeed * (1 + dashSpeedBoostPercentage / 100); //!

        dashInCooldown = false;
    }

    public void Dash()
    {
        if (!dashInCooldown)
        {
            StartCoroutine(Dashing());
        }
    }

    private void Update()
    {
        dashCurrentCooldown -= Time.deltaTime;

        if (dashCurrentCooldown <= 0)
        {
            dashInCooldown = false;
        }
        dashSpeed = playerController.baseSpeed * (1 + dashSpeedBoostPercentage / 100); //Does not work if it's in the "Start" function //!
    }

    IEnumerator Dashing() 
    {
        dashInCooldown = true;
        dashCurrentCooldown = dashTotalCooldown;

        playerController.SetCurrentSpeed(dashSpeed);

        yield return new WaitForSeconds(dashDuration);

        playerController.SetCurrentSpeed(playerController.baseSpeed);
    }

}
