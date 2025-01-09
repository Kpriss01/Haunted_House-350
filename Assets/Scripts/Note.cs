using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InteractiveNote : MonoBehaviour
{
    public GameObject noteTextUI; // Reference to the UI panel displaying the text
    private bool playerNearby = false;
    private bool noteActive = false;

    void Update()
    {
        // Check if the player is nearby and presses the interact button
        if (playerNearby && Input.GetKeyDown(KeyCode.I))
        {
            ToggleNote();
        }
    }

    private void ToggleNote()
    {
        noteActive = !noteActive; // Toggle the note's active state
        noteTextUI.SetActive(noteActive); // Show or hide the text UI
    }

    // Trigger when the player enters the note's range
    private void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.LogError("Player entered the note's range.");
        if (other.CompareTag("Player")) // Ensure it's the player
        {
            playerNearby = true;
            UnityEngine.Debug.LogError("Player is near the note. Press 'I' to interact.");
        }
    }

    // Trigger when the player leaves the note's range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            noteTextUI.SetActive(false); // Hide the note text if the player leaves
            noteActive = false; // Reset the note's active state
            UnityEngine.Debug.LogError("Player left the note's range.");
        }
    }
}
