using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoconutManager : MonoBehaviour
{
    Text Coconut_Counter;

    void Awake()
    {
        Coconut_Counter = GetComponent<Text>();
    }

    void Update()
    {
        Coconut_Counter.text = MelvinManager.currentCoconutCount.ToString();
    }
}
