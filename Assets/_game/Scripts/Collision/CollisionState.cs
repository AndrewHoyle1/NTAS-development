using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionState : MonoBehaviour
{

    public LayerMask collisionLayer;
    public LayerMask boundaryLayer;
    public LayerMask hazardsLayer;
    public LayerMask breakableLayer;
    public LayerMask npcLayer;
    public bool standing;
    public bool onWall;
    public bool outOfBounds;
    public bool hitHazard;
    public bool canPassThroughVert;
    public bool canPassThroughHorz;
    public bool canVertBoost;
    public bool canHorzBoost;
    public bool npcInteractionTop;
    public bool npcInteractionSide;
    public Vector2 bottomPosition = Vector2.zero;
    public Vector2 leftPosition = Vector2.zero;
    public Vector2 rightPosition = Vector2.zero;
    public float collisionRadius = 0.5f;
    public float colliderDelay = 0.5f;
    public Color debugCollisionColor = Color.red;

    private InputState inputState;
    private Stack stack;

    private void Awake()
    {
        inputState = GetComponent<InputState>();
        stack = GetComponent<Stack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        var pos = bottomPosition;

        if (stack.connectedSide)
        {
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer) || Physics2D.OverlapCircle(pos, collisionRadius, breakableLayer);

            outOfBounds = (Physics2D.OverlapCircle(pos, collisionRadius, boundaryLayer) && !standing);

            hitHazard = (Physics2D.OverlapCircle(pos, collisionRadius, hazardsLayer));

            npcInteractionTop = (Physics2D.OverlapCircle(pos, collisionRadius, npcLayer));

            pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;
            
            if (inputState.direction == Directions.Right)
            {
                pos.x += transform.position.x + 1;
            }
            else if (inputState.direction == Directions.Left)
            {
                pos.x += transform.position.x - 1;
            }
            pos.y += transform.position.y;

            onWall = ((Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer) || Physics2D.OverlapCircle(pos, collisionRadius, breakableLayer)) && !standing);

            npcInteractionSide = (Physics2D.OverlapCircle(pos, collisionRadius, npcLayer));
        }
        else if (stack.connectedTop)
        {
            pos.x += transform.position.x;
            pos.y += transform.position.y - 1;

            standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer) || Physics2D.OverlapCircle(pos, collisionRadius, breakableLayer);

            outOfBounds = (Physics2D.OverlapCircle(pos, collisionRadius, boundaryLayer) && !standing);

            hitHazard = (Physics2D.OverlapCircle(pos, collisionRadius, hazardsLayer));

            npcInteractionTop = (Physics2D.OverlapCircle(pos, collisionRadius, npcLayer));

            pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            onWall = ((Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer) || Physics2D.OverlapCircle(pos, collisionRadius, breakableLayer)) && !standing);

            npcInteractionSide = (Physics2D.OverlapCircle(pos, collisionRadius, npcLayer));
        }
        else
        {
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            standing = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer) || Physics2D.OverlapCircle(pos, collisionRadius, breakableLayer);

            outOfBounds = (Physics2D.OverlapCircle(pos, collisionRadius, boundaryLayer) && !standing);

            hitHazard = (Physics2D.OverlapCircle(pos, collisionRadius, hazardsLayer));

            npcInteractionTop = (Physics2D.OverlapCircle(pos, collisionRadius, npcLayer));

            pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            onWall = ((Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer) || Physics2D.OverlapCircle(pos, collisionRadius, breakableLayer)) && !standing);

            npcInteractionSide = (Physics2D.OverlapCircle(pos, collisionRadius, npcLayer));
        }
       
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 11)  //Kind of a gross way to do it
        {
            if (canPassThroughHorz)
            {
                var wall = col.gameObject;
                Destroy(wall);
                canHorzBoost = true;
            }
            else if (canPassThroughVert)
            {
                var wall = col.gameObject;
                Destroy(wall);
                canVertBoost = true;
            }
        }
    }
}
