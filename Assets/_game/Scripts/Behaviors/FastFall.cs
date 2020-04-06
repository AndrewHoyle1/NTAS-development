using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFall : AbstractBehavior
{

    public float fastFallMultiplier = 2f;
    public int ffCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var velY = body2d.velocity.y;
        var canFF = inputState.GetButtonValue(inputButtons[0]);

        if (!collisionState.standing && !collisionState.onWall && velY < 0f && canFF && ffCount > 0)
        {
            ffCount -- ;
            OnFastFall();
        }
        else if (collisionState.standing)
        {
            ffCount = 1;
        }
    }

    protected void OnFastFall()
    {
        var vel = body2d.velocity;

        body2d.velocity = new Vector2(vel.x, vel.y * fastFallMultiplier);
        print("fastFall");
    }
}
