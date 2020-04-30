using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMover : MonoBehaviour
{
    public float speed = 10f;
    public float turnTime = 5f; //How long in between turns

    private float direction;
    private float timeLeft; //Current time until it turns around

    public Rigidbody2D body2d;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = turnTime;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            body2d.velocity = new Vector2(speed * direction, 0);
        }
        else
        {
            direction = direction * (-1);
            timeLeft = turnTime;
        }
    }
}
