using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashSpeedBoostPercentage;
    private float dashSpeed;
    [SerializeField] private float dashDuration;

    [SerializeField] private float dashTotalCooldown; //Needs to be higher than "dashDuration"
    private float dashCurrentCooldown;
    private bool isDashInCooldown;

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();

        dashSpeed = playerController.baseSpeed * (1 + dashSpeedBoostPercentage / 100);

        isDashInCooldown = false;
    }

    public void Dash()
    {
        if (!isDashInCooldown)
        {
            StartCoroutine(Dashing());
        }
    }

    private void Update()
    {
        dashCurrentCooldown -= Time.deltaTime;

        if (dashCurrentCooldown <= 0)
        {
            isDashInCooldown = false;
        }
    }

    IEnumerator Dashing()
    {
        isDashInCooldown = true;
        dashCurrentCooldown = dashTotalCooldown;

        playerController.SetCurrentSpeed(dashSpeed);

        yield return new WaitForSeconds(dashDuration);

        playerController.SetCurrentSpeed(playerController.baseSpeed);
    }

}
