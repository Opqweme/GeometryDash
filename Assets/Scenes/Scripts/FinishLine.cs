using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public TextMeshProUGUI levelCompleteText; // Reference to the TextMeshProUGUI component

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Check if the levelCompleteText reference is not assigned
        if (levelCompleteText == null)
        {
            Debug.LogError("levelCompleteText reference is not assigned! Make sure to assign the TextMeshProUGUI component in the Inspector.");
        }
    }

    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered!");
        // Check if the object that entered the trigger is the player or the object you want to detect
        if (other.CompareTag("Player")) // Change "Player" to the tag of your player object
        {
            Debug.Log("Trigger entered by: " + other.tag);
            // Check if the levelCompleteText reference is assigned
            if (levelCompleteText != null)
            {
                Debug.Log("levelCompleteText is null: " + (levelCompleteText == null));
                // Update the TextMeshProUGUI component's text property to display "Level Complete"
                Debug.Log("Text updated: " + levelCompleteText.text);
                levelCompleteText.text = "Level Complete";
                // Add any additional logic here such as displaying a victory message, playing a sound, etc.
            }
            else
            {
                Debug.LogWarning("levelCompleteText reference is not assigned! TextMeshProUGUI component will not be updated.");
            }
        }
    }
}
