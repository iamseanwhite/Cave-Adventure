using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTracker : MonoBehaviour
{
    private bool swordStatus = false;
    private bool shovelStatus = false;
    private bool mapStatus = false;
    private bool ropeStatus = false;

    public void addSword()
    {
        swordStatus = true;
    }

    public void addShovel()
    {
        shovelStatus = true;
    }

    public void addMap()
    {
        mapStatus = true;
    }

    public void addRope()
    {
        ropeStatus = true;
    }

    public bool hasSword()
    {
        return swordStatus;
    }


    public bool hasShovel()
    {
        return shovelStatus;
    }


    public bool hasMap()
    {
        return mapStatus;
    }

    public bool hasRope()
    {
        return ropeStatus;
    }

}
