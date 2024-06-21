using UnityEngine;


public class Stats : MonoBehaviour
{
    [SerializeField]
    private float baseMaxHealth;
    public float currentRemainingHealth { get; private set; }

    private HealthBar healthBar;

    [SerializeField]
    private int baseDamage;

    private bool isDead = false;

    public float baseSpeed;


    private void Start()
    {
        currentRemainingHealth = baseMaxHealth;
        
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.ShowHealthBar(false);
    }
    private void Update()
    {
        if (currentRemainingHealth < baseMaxHealth)
        {
            healthBar.ShowHealthBar(true);
        }
    }
    public void TakeDamage(int damage)
    {
        currentRemainingHealth -= damage;

        if (currentRemainingHealth <= 0)
        {
            isDead = true;

            AudioManager.instance.PlaySFX(AudioManager.instance.die, 3.0f);
        }
        else
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.damage, 1.0f);
        }

        if (isDead)
        {
            if (gameObject.tag == EnemyController.enemyTag)
            {
                Destroy(gameObject);
            }
            if (gameObject.tag == PlayerController.playerTag)
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
