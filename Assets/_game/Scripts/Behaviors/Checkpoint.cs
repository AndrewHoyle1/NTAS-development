using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Checkpoint")
        {
            triggered = true;
        }
    }
}
