using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehavior
{
    public float jumpSpeed = 100f;
    public float jumpDelay = .1f;
    public int jumpCount;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;

    public Transform jumpParticles;

    private Transform clone;


    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionState.stacked)
        {
            jumpCount = 2;
        }
        else
        {
            jumpCount = 1;
        }
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);
        if (collisionState.standing)
        {
            if (canJump && holdTime < .1f)
            {
                jumpsRemaining = jumpCount - 1;
                OnJump();
            }
        }
        else
        {
            if (canJump && holdTime < .1f && Time.time - lastJumpTime > jumpDelay)
            {
                if (jumpsRemaining > 0)
                {
                    OnJump();
                    jumpsRemaining--;
                }
            }
        }        
    }

    protected virtual void OnJump()
    {
        var vel = body2d.velocity;
        lastJumpTime = Time.time;
        body2d.velocity = new Vector2(vel.x, jumpSpeed);
        if (collisionState.stacked)
        {
            clone = Instantiate(jumpParticles, transform.position, Quaternion.identity);
            clone.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            Destroy(clone.gameObject, 0.25f);
        }
        StartCoroutine(ScriptsDelay(jumpDelay));
    }
}
