using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;  // Required for SceneManager to load the next scene.

public class Door : MonoBehaviour
{
    //public int requiredKeys = 1;  // Number of keys required to open the door
    private bool doorOpen = false; // To ensure the door opens only once
    private InventoryManager inventoryManager;  // Reference to the InventoryManager script


    private void Start()
    {
        // Get the InventoryManager script component
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }


    // This function is triggered when the player enters the door's trigger area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !doorOpen)
        {
            if(inventoryManager == null)
            {
                UnityEngine.Debug.LogError("InventoryManager is not found. Make sure the InventoryManager script is attached to a GameObject named InventoryManager.");
            }
            for (int i = 0; i < inventoryManager.itemSlot.Length; i++)
            {
                if (inventoryManager.itemSlot[i].itemName == "Key")
                {
                    // If the player does not have the required keys, return
                    OpenDoor();
                }
            }
        }
    }

    // This function handles opening the door and loading the next scene
    private void OpenDoor()
    {
        doorOpen = true;


        // Check the current scene and load the appropriate next scene
        if (SceneManager.GetActiveScene().name == "Stage-1")
        {
            // If currently in Stage-1, load Stage-2
            SceneManager.LoadScene("Stage-2");
        }
        else if (SceneManager.GetActiveScene().name == "Stage-2")
        {
            // If currently in Stage-2, load Stage-3
            SceneManager.LoadScene("monster");
        }
        else if (SceneManager.GetActiveScene().name == "monster")
        {
            //unsure how to transition to exit screen 
            SceneManager.LoadScene("GameOver");  // Replace with your desired scene
        }
    }
}