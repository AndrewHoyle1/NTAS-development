using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AbstractBehavior
{
    public float dashVelX = 10f;
    public float dashVelY = 0f;
    public float dashDuration = 0.5f;
    protected float lastDashTime = 0;

    public Transform dashParticles;

    private Transform clone;

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
        lastDashTime = Time.time;
        inputState.direction = inputState.direction == Directions.Right ? Directions.Right : Directions.Left;
        body2d.velocity = new Vector2(dashVelX * (float)inputState.direction, dashVelY);
        Transform clone = Instantiate(dashParticles, transform.position, Quaternion.identity);
        StartCoroutine(ScriptsDelay(dashDuration));
        StartCoroutine(passAllower());
        Destroy(clone.gameObject, 0.25f);
    }

    protected IEnumerator passAllower()  //Makes the player able to pass through certain walls for the duration of the dash
    {
        collisionState.canPassThroughHorz = true;
        yield return new WaitForSeconds(dashDuration);
        collisionState.canPassThroughHorz = false;        
    }
}
