using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheckpoint : MonoBehaviour
{
    public bool hasCollided;

    public Animator animator;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && hasCollided == false)
        {
            hasCollided = true;            
            StartCoroutine(animationDelayer());
        }
    }

    protected IEnumerator animationDelayer()  //Makes the player able to pass through certain walls for the duration of the dash
    {
        
        animator.SetInteger("FlagState", 1);
        print("pre");
        yield return new WaitForSeconds(5);
        animator.SetInteger("FlagState", 2);
        print("post");
    }
}
