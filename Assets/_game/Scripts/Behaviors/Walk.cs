using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehavior
{
    public float speed = 400f;
    public float runMultiplier = 2f;
    public bool running;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        running = false;

        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);

        if (right || left)
        {
            var tmpSpeed = speed;

            if(run && runMultiplier > 0)
            {
                tmpSpeed *= runMultiplier;
                running = true;
            }

            var velX = tmpSpeed * (float)inputState.direction;

            body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }

    }
}
