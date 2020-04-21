using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : AbstractBehavior
{
    public GameObject npc;


    public void Interact()
    {
        npc.transform.SetParent(GetComponent<Transform>());

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var canStack = inputState.GetButtonValue(inputButtons[0]);

        if (collisionState.npcInteractionSide && canStack)
        {
            Interact();
        }

    }
}
