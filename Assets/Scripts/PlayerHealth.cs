using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PlayerHealth : PlayerController {

    #region Singleton
    public static PlayerHealth instance;
    bool alreadyDead = false;

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
    AudioSource deathMusic;

	void Start () {
        currentHealth = initalHealth;
        healthTotal = healthBar.rectTransform.sizeDelta.x;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        deathMusic = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>()[3];
    }

    void OnLevelWasLoaded()
    {
        Vector3 correctHealthBarPosition = transform.position;
        //correctHealthBarPosition.x += 0;
        //correctHealthBarPosition.y += 0;
        transform.position = correctHealthBarPosition;
        alreadyDead = false;
    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        healthText.text = currentHealth.ToString();
        healthBar.rectTransform.sizeDelta = new Vector2((currentHealth / 100.0f) * healthTotal, 20);
        //myCamera.GetComponent<CameraMotionBlur>().enabled = true;

        if (currentHealth == 0 && !alreadyDead)
        {
            Die();
        }
    }

    void Die()
    {
        alreadyDead = true;
        Debug.Log("Setting IsDead to true");
        animator.SetBool("IsDead", true);
        deathMusic.Play();
        Invoke("ReloadScene", 4f);       
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
