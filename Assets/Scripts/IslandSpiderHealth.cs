using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpiderHealth : MonoBehaviour {

    public const int maxHealth = 20;
    public int currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
}
