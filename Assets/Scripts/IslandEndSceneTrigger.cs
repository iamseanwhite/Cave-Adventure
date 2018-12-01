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
        GameObject goalmet = GameObject.Find("GoalTracker");
        GoalTracker goalTracker = goalmet.GetComponent<GoalTracker>();
        if (goalTracker.hasSword() && goalTracker.hasShovel() && goalTracker.hasMap() && goalTracker.hasRope())
        {
            //end scene and go to next.
        }
    }
}
