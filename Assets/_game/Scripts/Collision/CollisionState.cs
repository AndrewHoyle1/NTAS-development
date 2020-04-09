using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour
{

    public LayerMask collisionLayer;
    public LayerMask boundaryLayer;
    public LayerMask hazardsLayer = 10;
    public bool standing;
    public bool onWall;
    public bool outOfBounds;
    public bool canDash;
    public bool hitHazard;
    public Vector2 bottomPosition = Vector2.zero;
    public Vector2 leftPosition = Vector2.zero;
    public Vector2 rightPosition = Vector2.zero;
    public float collisionRadius = 0.5f;
    public Color debugCollisionColor = Color.red;

    private InputState inputState;

    private void Awake()
    {
        inputState = GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);

        outOfBounds = (Physics2D.OverlapCircle(pos, collisionRadius, boundaryLayer) && !standing);

        hitHazard = (Physics2D.OverlapCircle(pos, collisionRadius, hazardsLayer));

        pos = inputState.direction == Directions.Right ? rightPosition: leftPosition; 
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        onWall = (Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer) && ! standing);

        var dashPos = bottomPosition;
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

        var positions = new Vector2[] { rightPosition, bottomPosition, leftPosition };

        foreach (var position in positions) {

            var pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            Gizmos.DrawWireCube(new Vector3(pos.x, pos.y, 0), new Vector3(collisionRadius, collisionRadius, 0));
        }
    }
}
