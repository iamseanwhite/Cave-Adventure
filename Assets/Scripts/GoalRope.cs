using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRope : MonoBehaviour {

    void Update()
    {
        var pc = GameObject.Find("Melvin");
        if (Vector3.Distance(pc.transform.position, this.transform.position) < 5)
        {
            updateRopeStatus();
        }
    }

    public void updateRopeStatus()
    {
        GameObject goalUpdater = GameObject.Find("GoalTracker");
        GoalTracker goalTracker = goalUpdater.GetComponent<GoalTracker>();
        goalTracker.addRope();
    }

}
