using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CopWinL1 : MonoBehaviour
{
    public void RestartButton()
    {

        HouseController houseController = FindObjectOfType<HouseController>();

        if (houseController != null)
        {
            // Call the ResetState() method to avoid overlapping
            houseController.ResetState();
        }
        else
        {
            Debug.LogWarning("HouseController not found in the scene.");
        }
        SceneManager.LoadScene("Level1");
    }
    public void MenuButton()
    {
        HouseController houseController = FindObjectOfType<HouseController>();

        if (houseController != null)
        {
            // Call the ResetState() method to avoid overlapping
            houseController.ResetState();
        }
        else
        {
            Debug.LogWarning("HouseController not found in the scene.");
        }
        SceneManager.LoadScene("MainMenu");
    }
}
