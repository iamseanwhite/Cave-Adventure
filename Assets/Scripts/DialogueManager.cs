using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager: MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> statements;

	// Use this for initialization
	void Start ()
	{
	    statements = new Queue<string>();
	}

    public void StartDialog(Dialogue dialogue)
    {
        Debug.Log("Dialogue Starting.");
        animator.SetBool("Open", true);

        nameText.text = dialogue.name;

        statements.Clear();

        foreach (string statement in dialogue.statements)
        {
            statements.Enqueue(statement);
        }

        DisplayNextStatement();
    }

    public void DisplayNextStatement()
    {
        if (statements.Count == 0)
        {
            EndDialogue();
            return;
        }

        string statement = statements.Dequeue();
        dialogueText.text = statement;
    }

    public void EndDialogue()
    {
        animator.SetBool("Open", false);
    }
}
