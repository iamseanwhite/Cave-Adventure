using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PlayerHealth : PlayerController {

    #region Singleton
    public static PlayerHealth instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public Text healthText;
    public Image healthBar;
    int initalHealth = 100;
    public int currentHealth;
    float healthTotal;
    Animator animator;

	void Start () {
        currentHealth = initalHealth;
        healthTotal = healthBar.rectTransform.sizeDelta.x;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        healthText.text = currentHealth.ToString();
        healthBar.rectTransform.sizeDelta = new Vector2((currentHealth / 100.0f) * healthTotal, 20);
        //myCamera.GetComponent<CameraMotionBlur>().enabled = true;

        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Setting IsDead to true");
        animator.SetBool("IsDead", true);
        Invoke("ReloadScene", 3f);
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
