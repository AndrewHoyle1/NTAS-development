using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : AbstractBehavior
{
    public GameObject npc;
    public bool connectedTop;
    public bool connectedSide;
    //public Component initialRb2d;

    public void Connect()
    {
        npc = GameObject.FindGameObjectWithTag("NPC");
        npc.transform.SetParent(gameObject.transform);
        Destroy(npc.GetComponent<Rigidbody2D>());
        //npc.transform.position = new Vector3(1, 0, 0);
        
    }

    public void Disconnect()
    {
        gameObject.transform.DetachChildren();
        npc.AddComponent<Rigidbody2D>();
        npc.GetComponent<Rigidbody2D>().freezeRotation = true;
        npc.GetComponent<Rigidbody2D>().useAutoMass = true;
        npc.GetComponent<Rigidbody2D>().simulated = true;
        npc.GetComponent<Rigidbody2D>().gravityScale = 8.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        connectedTop = false;
        connectedSide = false;
    }

    // Update is called once per frame
    void Update()
    {
        var canStack = inputState.GetButtonValue(inputButtons[0]);
        var canUnstack = inputState.GetButtonValue(inputButtons[1]);

        if (canStack && collisionState.npcInteractionSide)
        {
            Connect();
            connectedSide = true;
        }
        else if (canStack && collisionState.npcInteractionTop) 
        {
            Connect();
            connectedTop = true;
        }
        else if (canUnstack && (connectedSide || connectedTop))
        {
            Disconnect();
            connectedTop = false;
            connectedSide = false;
        }


    }
}
