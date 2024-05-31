using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stats : MonoBehaviour
{
    [SerializeField]
    private float baseMaxHealth;
    public float currentRemainingHealth { get; private set; }

    [SerializeField]
    private int baseDamage;

    bool isDead = false;

    public float baseSpeed;

    private void Start() 
    {
        currentRemainingHealth = baseMaxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentRemainingHealth -= damage;

        if (currentRemainingHealth <= 0)
        {
            Debug.Log("Death");
            isDead = true;

            AudioManager.instance.PlaySFX(AudioManager.instance.die, 3.0f);
        }
        else
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.damage, 1.0f);
        }

        if (isDead)
        {
            if (gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
            if (gameObject.tag == "Player")
            {
                GameSceneManager.instance.LoadMainMenu();
            }
        }
    }

    public float GetMaxHealth()
    {
        return baseMaxHealth;
    }

    public int GetBaseDamage()
    {
        return baseDamage;
    }
}
