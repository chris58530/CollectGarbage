using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureBase : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    [SerializeField] private Image healthBar;
     [SerializeField] private WorldCanvas worldCanvas;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth / maxHealth;

    }
    public void GetHurt(float damage)
    {
        worldCanvas.SetText($"Shoot {damage}", 1);

        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;
        if (healthBar.fillAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
