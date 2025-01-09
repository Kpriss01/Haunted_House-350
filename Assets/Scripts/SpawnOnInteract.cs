using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpawnOnInteract : MonoBehaviour
{
    [SerializeField] public GameObject objectToSpawn; // The GameObject to spawn
    [SerializeField] public Transform spawnLocation; // Location to spawn the object (optional)
    private bool playerNearby = false;

    void Update()
    {
        // Check if the player is nearby and presses the interact key
        if (playerNearby && Input.GetKeyDown(KeyCode.I))
        {
            SpawnObject();
        }
    }
    
    private void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            // Spawn the object at the specified location or the current position of this object
            Instantiate(objectToSpawn, spawnLocation ? spawnLocation.position : transform.position, Quaternion.identity);
            UnityEngine.Debug.Log("Object spawned: " + objectToSpawn.name);
        }
        else
        {
            UnityEngine.Debug.LogWarning("No object assigned to spawn!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player
        {
            playerNearby = true;
            UnityEngine.Debug.Log("Player is near the spawn area. Press 'I' to interact.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            UnityEngine.Debug.Log("Player left the spawn area.");
        }
    }
}
