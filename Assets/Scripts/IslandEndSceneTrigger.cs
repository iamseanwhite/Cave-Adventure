using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandEndSceneTrigger : MonoBehaviour {

    public GameObject Melvin;
    public GameObject GateGuard;

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
        //use InventoryUI.CS and test for presence of Shovel, Map, and Rope. If possessed,
        //transition to next scene. If not, don't.
    }
}
