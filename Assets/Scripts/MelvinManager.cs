using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelvinManager : MonoBehaviour
{

    public static int currentCoconutCount;
    public int tempCurrentCoconutCount;
    public bool collectingCoconuts;
    public Animator anim;

    void Awake()
    {
        currentCoconutCount = 0;
        tempCurrentCoconutCount = 0;
        collectingCoconuts = false;
    }

    void Update()
    {
        if (collectingCoconuts)
        {
            if (tempCurrentCoconutCount >= 60)
            {
                currentCoconutCount = currentCoconutCount + 1;
                tempCurrentCoconutCount = 0;
            }
            else
            {
                tempCurrentCoconutCount = tempCurrentCoconutCount + 1;
            }
        }
    }

    void OnTriggerEnter(Collider theObject)
    {
        if (theObject.gameObject.CompareTag("Coconut"))
        {
            collectingCoconuts = true;
            currentCoconutCount = currentCoconutCount + 1;
        }
    }

    void OnTriggerExit(Collider theObject)
    {
        if (theObject.gameObject.CompareTag("Coconut"))
        {
            collectingCoconuts = false;
        }
    }
}

