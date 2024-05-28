using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private int baseMaxHealth;
    private int currentRemainingHealth;

    [SerializeField]
    private int a_baseDamage;
    public int baseDamage { get; private set; }

    bool isDead = false;

    public float baseSpeed;

    private void Start() 
    {
        baseDamage = a_baseDamage;

        currentRemainingHealth = baseMaxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentRemainingHealth -= damage;

        if (currentRemainingHealth <= 0)
        {
            Debug.Log("Death");
            isDead = true;

            AudioManager.instance.PlaySFX(AudioManager.instance.die);
        }
        else
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.damage);
        }

        if (isDead)
        {
            Destroy(gameObject);
        }
    }
}
