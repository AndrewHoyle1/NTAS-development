using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehavior : MonoBehaviour
{

    public ButtonAssignments[] inputButtons;
    public MonoBehaviour[] disableScripts;

    protected InputState inputState;
    protected Rigidbody2D body2d;
    protected CollisionState collisionState;

    protected virtual void Awake()
    {
        inputState = GetComponent<InputState>();
        body2d = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

    protected virtual void ToggleScripts(bool value) //Can disable a script while a condition is met
    {
        foreach(var script in disableScripts)
        {
            script.enabled = value;
        }
    }

    protected IEnumerator ScriptsDelay(float delay)  //Delays scripts for a set amount of time
    {
        ToggleScripts(false);
        //print("wow");
        yield return new WaitForSeconds(delay);
        ToggleScripts(true);
    }
}
