using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AbstractBehavior
{
    public float dashLen = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var canDash = inputState.GetButtonValue(inputButtons[0]);

        if (canDash)
        {
            OnDash();
        }
    }

    protected virtual void OnDash()
    {
        var pos = body2d.position;
        if (inputState.direction == Directions.Right)
        {
            body2d.position = new Vector2(pos.x + dashLen, pos.y);
        }
        else if (inputState.direction == Directions.Left)
        {
            body2d.position = new Vector2(pos.x - dashLen, pos.y);
        }
    }
}
