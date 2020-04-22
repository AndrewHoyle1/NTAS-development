using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : AbstractBehavior
{
    public GameObject npc;
    public bool connected;
    //public Component initialRb2d;

    public void Connect()
    {
        npc = GameObject.FindGameObjectWithTag("NPC");
        npc.transform.SetParent(gameObject.transform);
        
    }

    public void Disconnect()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        connected = false;
    }

    // Update is called once per frame
    void Update()
    {
        var canStack = inputState.GetButtonValue(inputButtons[0]);

        if (canStack && collisionState.npcInteractionSide)
        {
            Connect();
            connected = true;
        }
        else if (canStack && connected == true) 
        {
            Disconnect();
        }


    }
}
