using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : AbstractBehavior
{
    public float boostVel = 10f;
    public float boostDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (collisionState.canHorzBoost)
        {
            OnHorzBoost();
            print("horz");
            StartCoroutine(ScriptsDelay(boostDuration));
            StartCoroutine(passAllower());
        }
        else if (collisionState.canVertBoost)
        {
            OnVertBoost();
            print("vert");
            StartCoroutine(ScriptsDelay(boostDuration));
            StartCoroutine(passAllower());
        }
    }

    protected virtual void OnHorzBoost()
    {
        inputState.direction = inputState.direction == Directions.Right ? Directions.Right : Directions.Left;
        body2d.velocity = new Vector2(boostVel * (float)inputState.direction, 1);        
    }

    protected virtual void OnVertBoost()
    {
        body2d.velocity = new Vector2(0, -boostVel);
    }

    protected IEnumerator passAllower()  //Makes the player able to pass through certain walls for the duration of the dash
    {
        yield return new WaitForSeconds(boostDuration);
        collisionState.canVertBoost = false;
        collisionState.canHorzBoost = false;
    }
}
