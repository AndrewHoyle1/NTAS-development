﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToWall : AbstractBehavior //Isn't attached to player because WallSlide extends this
{
    public bool onWallDetected;
    
    public float wallGravityScale = 0;
    public float wallDrag = 100;
    protected float defaultGravityScale;
    protected float defaultDrag;
    // Start is called before the first frame update
    void Start()
    {
        defaultGravityScale = body2d.gravityScale;
        defaultDrag = body2d.drag;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (collisionState.onWall)
        {
            if (!onWallDetected)
            {
                OnStick();
                ToggleScripts(false);
                onWallDetected = true;
            }
        }

        else
        {
            if (onWallDetected)
            {
                OffWall();
                ToggleScripts(true);
                onWallDetected = false;
            }
        }
    }

    protected virtual void OnStick()
    {
        if(!collisionState.standing)
        {
            print("haha");
            body2d.gravityScale = 0;
            body2d.drag = 100;
        }
    }

    protected virtual void OffWall()
    {
        if(body2d.gravityScale != defaultGravityScale)
        {
            body2d.gravityScale = defaultGravityScale;
            body2d.drag = defaultDrag;
        }
    }
}
