using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour
{

    public LayerMask collisionLayer;
    public bool standing;
    public bool canDash;
    public Vector2 bottomPosition = Vector2.zero;
    public float collisionRadius = 2f;
    public Color debugCollisionColor = Color.red;

    protected InputState inputState;

    protected virtual void Awake()
    {
        inputState = GetComponent<InputState>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        var pos = bottomPosition;
        var dashPos = bottomPosition;

        pos.x += transform.position.x;
        pos.y += transform.position.y;

        standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);
        
        if (inputState.direction == Directions.Right)
        {
            dashPos.x += (transform.position.x + 2); // change this is if you change dashlength
        }
        else if (inputState.direction == Directions.Left)
        {
            dashPos.x += (transform.position.x - 2);
        }
        dashPos.y += transform.position.y;

        canDash = Physics2D.OverlapCircle(dashPos, collisionRadius, collisionLayer);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = debugCollisionColor;

        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, collisionRadius);
    }
}
