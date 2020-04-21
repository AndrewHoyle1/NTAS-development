using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullGameManager : MonoBehaviour
{
    public CollisionState collisionState;
    public SpawnPoint playerSpawnPoint;
    public SpawnPoint npcSpawnPoint;
    public GameObject player;
    public GameObject npc;
    public Animator animator;

    public static FullGameManager sharedInstance = null;
    public CameraManager cameraManager;

    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            // We only ever want one instance to exist, so destroy the other existing object
            Destroy(gameObject);
        }
        else
        {
            // If this is the only instance, then assign the sharedInstance variable to the current object.
            sharedInstance = this;
        }

        // Consolidate all the logic to setup a scene inside a single method. 
        // This makes it easier to call again in the future, in places other than the Start() method.
        // call in Awake() so other scripts can access Player in Start()
        SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer();
        SpawnNPC();
    }

    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            player = playerSpawnPoint.SpawnObject();
        }
    }

    public void SpawnNPC()
    {
        if (npcSpawnPoint != null)
        {
            npc = npcSpawnPoint.SpawnObject();
        }
    }

    IEnumerator Delay(float delay)
    {
        //Debug.Log("Started Delay at " + Time.time);
        yield return new WaitForSeconds(delay);
        //Debug.Log("Ended Delay at " + Time.time);

        player.GetComponent<Transform>().position = playerSpawnPoint.transform.position;
    }
    void RespawnPlayer()
    {
        collisionState = player.GetComponent<CollisionState>();
        if (collisionState.outOfBounds || collisionState.hitHazard)
        {
            StartCoroutine(Delay(0.5f));
            animator = player.GetComponent<Animator>();
            animator.SetInteger("AnimState", 2);
            Delay(0.5f);
        }

    }

    void Start()
    {
        // call in Start() to guarantee the GameObject is on scene
        cameraManager.virtualCamera.Follow = player.transform;
    }

    private void Update()
    {
        RespawnPlayer();
    }

}
