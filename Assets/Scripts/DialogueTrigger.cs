using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject Melvin;
    public GameObject GateGuard;
    public bool wasTriggered = false;

    void Update()
    {
        float dist = Vector3.Distance(Melvin.transform.position, GateGuard.transform.position);

        if (dist < 10)
        {
           TriggerDialogue();
        }

        if (dist > 15)
        {
           FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialog(dialogue);
    }
}
