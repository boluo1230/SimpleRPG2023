using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCObject : InteractableObject
{

    public string nameText;
    public string[] contentTextArr;

    public DialogueUI dialogueUI;

    protected override void Interact()
    {
        Debug.Log("NPCObject Interact process");
        dialogueUI.show(nameText, contentTextArr);
    }
}
