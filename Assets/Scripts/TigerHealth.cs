using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TigerHealth : MonoBehaviour {

    #region Singleton
    public static TigerHealth instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Image healthBar;
    int initalHealth = 100;
    public int currentHealth;
    public GameObject Melvin;
    float healthTotal;



    void Start()
    {
        currentHealth = initalHealth;
        healthTotal = healthBar.rectTransform.sizeDelta.x;
        
    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        //Debug.Log("current health calculation: " + currentHealth);
        //Debug.Log("healthtotal calculation: " + healthTotal);
        //Debug.Log("health calculation: " + ((currentHealth / 100.0f)* healthTotal));
        healthBar.rectTransform.sizeDelta = new Vector2((currentHealth/ 100.0f) * healthTotal , 20);
    }
}
