using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject Melvin;
    public GameObject GateGuard;

    public void TriggerDialogue()
    {
        float dist = Vector3.Distance(Melvin.transform.position, GateGuard.transform.position);
        if (dist < 20)
        {
            FindObjectOfType<DialogueManager>().StartDialog(dialogue);
        }
    }
}
