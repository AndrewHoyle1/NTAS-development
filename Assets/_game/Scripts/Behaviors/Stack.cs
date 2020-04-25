using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : AbstractBehavior
{
    public GameObject npc;
    public bool connectedTop;
    public bool connectedSide;
    public Rigidbody2D rigidbody2D;
    //public Component initialRb2d;

    public void Connect()
    {
        npc.transform.SetParent(gameObject.transform);
        //Destroy(npc.GetComponent<Rigidbody2D>());
        rigidbody2D.isKinematic = true;
        //npc.transform.position = new Vector3(1, 0, 0);

    }

    public void Disconnect()
    {
        print("unstack");
        gameObject.transform.DetachChildren();
        rigidbody2D.isKinematic = false;
        connectedSide = false;
        connectedTop = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        connectedTop = false;
        connectedSide = false;
        npc = GameObject.FindGameObjectWithTag("NPC");
        rigidbody2D = npc.GetComponent<Rigidbody2D>();
    }

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
        if (canUnstack && (connectedSide || connectedTop))
        {
            //Debug.Log("Disconnect");
            Disconnect();
        }


    }
}
