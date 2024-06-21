using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Stats characterStats;

    private Slider healthBar;

    private float healthProgression;

    private void Awake()
    {
        characterStats = GetComponentInParent<Stats>();
        healthBar = GetComponent<Slider>();
    }
    private void Update()
    {
        healthProgression = characterStats.currentRemainingHealth / characterStats.GetMaxHealth();
        healthBar.value = healthProgression;
    }

    public void ShowHealthBar(bool b)
    {
        if (b)
        {
            healthBar.gameObject.SetActive(true);
        }
        else
        {
            healthBar.gameObject.SetActive(false);
        }
    }

}
