using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class Spider4Health : MonoBehaviour
{
   
    #region Singleton
    public static Spider4Health instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Image healthBar;
    int initalHealth = 100;
    public int currentHealth;
    public GameObject Spider;
    float healthTotal;
    private Animator anim;


    // Use this for initialization
    void Start()
    {
        currentHealth = initalHealth;
        healthTotal = healthBar.rectTransform.sizeDelta.x;
        anim = Spider.GetComponent<Animator>();

    }

    // Update is called once per frame
    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        //Debug.Log("current health calculation: " + currentHealth);
        //Debug.Log("healthtotal calculation: " + healthTotal);
        Debug.Log("health calculation: " + ((currentHealth / 100.0f) * healthTotal));
        healthBar.rectTransform.sizeDelta = new Vector2((currentHealth / 100.0f) * healthTotal, 20);

        if (currentHealth == 0)
        {
            Debug.Log("Spider dead");
            anim.SetBool("isDead", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isTaunting", false);
            anim.SetBool("isRunning", false);
            Spider.SetActive(!Spider.activeSelf);

        }

    }
}



