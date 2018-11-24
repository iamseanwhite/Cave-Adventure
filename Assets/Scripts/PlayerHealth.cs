using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : PlayerController {

    public Text healthText;
    int initalHealth = 100;
    int currentHealth;

	void Start () {
        currentHealth = initalHealth;
	}
	
	
	void Update () {    
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentHealth -= 10;
            currentHealth = Mathf.Clamp(currentHealth, 0, 100);
            healthText.text = currentHealth.ToString();
        }
	}
}
