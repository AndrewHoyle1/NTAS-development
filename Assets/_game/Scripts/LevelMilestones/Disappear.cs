using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Disappear : MonoBehaviour
{
    public TilemapRenderer tilemapRenderer;
    public TilemapCollider2D tilemapCollider;
    public bool present; //Tells if the plat is present.
    public bool startPresent;

    public float presentTime; //How long the plat is active
    public float goneTime; //How long it's gone
    private float currentWaitTime; //How long until the next change

    void Start()
    {
        currentWaitTime = presentTime;
        present = startPresent;
    }
    
    // Update is called once per frame
    void Update()
    {
        currentWaitTime -= Time.deltaTime;
        if (currentWaitTime < 0)
        {
            if(present == true)
            {
                tilemapCollider.enabled = false;
                tilemapRenderer.enabled = false;
                present = false;
                currentWaitTime = goneTime;
            }
            else
            {
                tilemapCollider.enabled = true;
                tilemapRenderer.enabled = true;
                present = true;
                currentWaitTime = presentTime;
            }
        }
    }


}
