using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GirlHealth : MonoBehaviour
{

    #region Singleton
    public static GirlHealth instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Image healthBar;
    int initalHealth = 100;
    public int currentHealth;
    //public GameObject Melvin;
    float healthTotal;
    Animator animator;


    void Start()
    {
        currentHealth = initalHealth;
        healthTotal = healthBar.rectTransform.sizeDelta.x;
        animator = GetComponent<Animator>();

    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        //Debug.Log("current health calculation: " + currentHealth);
        //Debug.Log("healthtotal calculation: " + healthTotal);
        //Debug.Log("health calculation: " + ((currentHealth / 100.0f)* healthTotal));
        healthBar.rectTransform.sizeDelta = new Vector2((currentHealth / 100.0f) * healthTotal, 20);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        InvokeRepeating("ReloadScene", 3f, 2f);
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
