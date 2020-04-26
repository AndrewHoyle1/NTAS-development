using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private Animator animator;
    private Transform parentTransform;
    private CollisionState parentCollisionState;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //print("ha2");
    }

    // Update is called once per frame
    void Update()
    {
        //if (parentCollisionState.outOfBounds || parentCollisionState.hitHazard)
        //{
        //    //print("ha");
        //    ChangeAnimationState(1);
        //}
        //else
        //{
        //    ChangeAnimationState(0);
        //}
    }

    void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }
}