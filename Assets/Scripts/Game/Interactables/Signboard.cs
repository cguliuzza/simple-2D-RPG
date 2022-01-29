using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signboard : Interactable
{
    public Dialogue dialogue;


    protected override void Interact()
    {
        Debug.Log("Interact");
        ProcessSignboard();
        base.Interact();
    }

    protected override void OutOfRange()
    {
        Debug.Log("Out of range");
        CloseSignboard();
        base.OutOfRange();
    }

    private void ProcessSignboard()
    {
        DialogueController.Instance.StartDialogue(dialogue);
    }

    private void CloseSignboard()
    {
        DialogueController.Instance.EndDialogue();
    }
}
