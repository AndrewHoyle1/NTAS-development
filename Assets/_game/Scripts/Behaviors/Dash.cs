using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AbstractBehavior
{
    public float dashVelX = 10f;
    public float dashVelY = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var canDash = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);
        if (canDash && holdTime < .1f)
        {
            OnDash();
        }
    }

    protected virtual void OnDash()
    {
        //print("Dash");
        inputState.direction = inputState.direction == Directions.Right ? Directions.Right : Directions.Left;
        body2d.velocity = new Vector2(dashVelX * (float)inputState.direction, dashVelY);
    }
}
