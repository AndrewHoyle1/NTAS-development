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
    public float stackStart = 1f;

    public void Connect()
    {
        print("Stack");
        npc.transform.SetParent(gameObject.transform);
        Destroy(rigidbody2D);
        Debug.Log("Connected");
        collisionState.stacked = true;
        //rigidbody2D.isKinematic = true;
        //npc.transform.position = new Vector3(1, 0, 0);

        StartCoroutine(ScriptsDelay(stackStart));
    }

    public void Disconnect()
    {
        print("unstack");
        gameObject.transform.DetachChildren();
        //rigidbody2D.isKinematic = false;
        npc.AddComponent<Rigidbody2D>();
        rigidbody2D = npc.GetComponent<Rigidbody2D>();
        rigidbody2D.simulated = true;
        rigidbody2D.useAutoMass = true;
        rigidbody2D.gravityScale = 8.0f;
        connectedSide = false;
        connectedTop = false;
        collisionState.stacked = false;
        Debug.Log("Disconnected");
        StartCoroutine(ScriptsDelay(stackStart));
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


        if (canStack && (connectedSide || connectedTop))
        {
            //print("Disconnect");
            Disconnect();
        }
        else
        {
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
        }
        
        


    }
}
