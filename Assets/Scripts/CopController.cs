using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopController : MonoBehaviour
{
    public GameObject copWinUI; // Reference to the UI GameObject to activate
    public GameObject RoundTextUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");
        // Check if the collided object is the Robber
        if (other.CompareTag("Robber"))
        {
            Debug.Log("Cop wins! Robber caught!");
            // Activate the UI GameObject
            if (copWinUI != null)
            {
                copWinUI.SetActive(true);
            }
            if (RoundTextUI != null)
            {
                RoundTextUI.SetActive(false);
            }
        }
    }
}
