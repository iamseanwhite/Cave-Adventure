using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : PlayerController {

    #region Singleton
    public static PlayerHealth instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Text healthText;
    int initalHealth = 100;
    public int currentHealth;

	void Start () {
        currentHealth = initalHealth;
	}

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        healthText.text = currentHealth.ToString();
    }
}
