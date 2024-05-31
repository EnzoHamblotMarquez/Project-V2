using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Stats stats;

    public Slider healthBar;

    private float healthProgression;

    private void Awake()
    {
        stats = GetComponentInParent<Stats>();
        healthBar = GetComponent<Slider>();
    }
    private void Update()
    {
        healthProgression = stats.currentRemainingHealth / stats.GetMaxHealth();
        healthBar.value = healthProgression;
    }
}
