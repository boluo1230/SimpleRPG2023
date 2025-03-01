using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickableObject : InteractableObject
{
    protected override void Interact()
    {
        Debug.Log("PickableObject Interact process");
    }
}
