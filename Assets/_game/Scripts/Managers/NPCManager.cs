using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private Animator animator;
    private CollisionState collisionState;

    void Awake()
    {
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

    }

    void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }
}