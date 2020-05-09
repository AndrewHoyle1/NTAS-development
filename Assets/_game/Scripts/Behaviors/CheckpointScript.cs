using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour //I actually think this stuff should all go into CollisionState
{
    public bool triggered1;
    public bool triggered2;
    public GameObject spawnPoint;
    public Vector3 mostRecentSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        triggered1 = false;
        triggered2 = false;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        mostRecentSpawnPoint = spawnPoint.GetComponent<Transform>().position;
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Checkpoint1" && triggered1 == false)
        {
            mostRecentSpawnPoint = collider.gameObject.GetComponent<Transform>().position;
            triggered1 = true;
            triggered2 = false;
        }
        else if(collider.gameObject.name == "Checkpoint2" && triggered2 == false)
        {
            triggered1 = false;
            triggered2 = true;
            mostRecentSpawnPoint = collider.gameObject.GetComponent<Transform>().position;
        }
    }
}
