using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private InputState inputState;
    private Walk walkBehavior;
    private Animator animator;
    private CollisionState collisionState;

    void Awake()
    {
        inputState = GetComponent<InputState>();
        walkBehavior = GetComponent<Walk>();
        animator = GetComponent<Animator>();
        collisionState = GetComponent<CollisionState>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //print("ha2");
    }

    // Update is called once per frame
    void Update()
    {
        //print(collisionState.standing);
        if(collisionState.outOfBounds)
        {
            //print("ha");
            ChangeAnimationState(1);
        }
        else
        {
            ChangeAnimationState(0);
        }

    }

    void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }
}
