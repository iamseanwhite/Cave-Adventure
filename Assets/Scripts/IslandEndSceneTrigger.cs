using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslandEndSceneTrigger : MonoBehaviour {

    public GameObject Melvin;
    public GameObject GateGuard;
    public Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        float dist = Vector3.Distance(Melvin.transform.position, GateGuard.transform.position);

        if (dist < 10)
        {
            endIfGoalsMet();
        }
    }

    public void endIfGoalsMet()
    {
        if (inventory.items.Count == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
