using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Health health;
    public Slider hpBar;

    private void FixedUpdate()
    {
        hpBar.value = health.currentHealth;
    }
}
