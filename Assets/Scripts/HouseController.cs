using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseController : MonoBehaviour
{
    public GameObject copObject; // Reference to the Cop GameObject
    public GameObject robObject; // Reference to the Cop GameObject
    public float moveSpeed = 5f; // Speed at which Cop moves towards the house
    public int[,] adjacencyMatrix = new int[,]
    {  //0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1
        {0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0}, //0
        {0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}, //1
        {1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0}, //2
        {1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0}, //3 
        {0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0}, //4
        {0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0},  //5
        {0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0}, //6
        {0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 1}, //7
        {0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0}, //8
        {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0}, //9 
        {0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1}, //10
        {0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0}  //11
    }; // Adjacency matrix representing house connectivity
    private static int copCurrentHouse = 11; // Variable indicating the Cop's current house
    private static int robCurrentHouse = 0; // Variable indicating the Robber's current house

    private bool movingToHouse = false; // Flag to indicate if player is moving to a house
    private Vector3 targetPosition; // Target position to move towards

    private static int currentRound = 0; // Variable indicating the current round (0 for Cop, 1 for Robber)
    public Text roundText; // Reference to the UI Text component

    private static int clickedHouseIndex;

    public void ResetState()
    {
        currentRound = 0;
        copCurrentHouse = 11;
        robCurrentHouse = 0;

    }
    void Start()
    {
        // Call the function to set the initial round text
        UpdateRoundText();
    }

    void Update()
    {
        if (movingToHouse)
        {
            GameObject playerObject = currentRound == 0 ? copObject : robObject; //Determine which player based on the round


            playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // If the player reaches near the house, stop moving
            if (Vector3.Distance(playerObject.transform.position, targetPosition) < 0.1f)
            {
                movingToHouse = false;
                //Debug.Log("Player reached the house.");

                // Update the current house of the active player
                if (currentRound == 0)
                {
                    copCurrentHouse = clickedHouseIndex;
                    //Debug.Log("Cop's current house updated: " + copCurrentHouse);

                }
                else
                {
                    robCurrentHouse = clickedHouseIndex;
                    //Debug.Log("Robber's current house updated: " + robCurrentHouse);
                }

                // Switch to the next round
                currentRound = (currentRound + 1) % 2; // Toggle between 0 and 1
                UpdateRoundText();
                //Debug.Log("Next round: " + (currentRound == 0 ? "Cop" : "Robber"));
            }
        }
    }

    void OnMouseDown()
    {
        //Debug.Log("Mouse Click Detected on House.");
        clickedHouseIndex = int.Parse(gameObject.name.Replace("house", "")); // Extract house index

        // Check if the clicked house is connected to the current house of the active player
        if (currentRound == 0 && adjacencyMatrix[copCurrentHouse, clickedHouseIndex] == 1)
        {
            //Debug.Log("Moving Cop towards the clicked house.");
            MovePlayer(copObject);
        }
        else if (currentRound == 1 && adjacencyMatrix[robCurrentHouse, clickedHouseIndex] == 1)
        {
            //Debug.Log("Moving Robber towards the clicked house.");
            MovePlayer(robObject);
        }
        else
        {
            //Debug.Log("The clicked house is not connected to the current player's house. Cannot move.");
        }
    }

    void MovePlayer(GameObject playerObject)
    {
        // Set the target position to the position of the clicked house
        targetPosition = transform.position; 
        // Start moving the player towards this house
        movingToHouse = true;
    }
    // Function to update the round text
    public void UpdateRoundText()
    {
        // Check the value of currentRound and update the text accordingly
        if (currentRound == 0)
        {
            roundText.text = "COP";
        }
        else if (currentRound == 1)
        {
            roundText.text = "ROBBER";
        }
    }


}
