using System.Collections;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    [SerializeField] private GameObject hintPanel; // UI to display the hints
    [SerializeField] private TMP_Text hintText;    // Text element for the hint
    [SerializeField] private float displayDuration = 5f; // Duration each hint is displayed

    private Coroutine currentHintCoroutine;

    private void Awake()
    {
        if (hintPanel != null)
        {
            hintPanel.SetActive(false); // Hide panel at the start
        }
    }

    /// Displays hint to player.
    /// <param name="message">The hint message to display.</param>
    public void ShowHint(string message)
    {
        // Stops any currently active hint
        if (currentHintCoroutine != null)
        {
            StopCoroutine(currentHintCoroutine);
        }

        // Shows the panel and the message
        hintPanel.SetActive(true);
        hintText.text = message;

        // Start a coroutine to hide the hint after a delay
        currentHintCoroutine = StartCoroutine(HideHintAfterDelay());
    }

    /// Hides the hint panel after the specified display duration.
    private IEnumerator HideHintAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        hintPanel.SetActive(false);
    }
}
