using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CopWin : MonoBehaviour
{
  public void RestartButton()
    {
        
        HouseControllerL0 houseController = FindObjectOfType<HouseControllerL0>();

        if (houseController != null)
        {
            // Call the ResetState() method to avoid overlapping
            houseController.ResetState();
        }
        else
        {
            Debug.LogWarning("HouseControllerL0 not found in the scene.");
        }
        SceneManager.LoadScene("Level0");
    }
    public void MenuButton()
    {
        HouseControllerL0 houseController = FindObjectOfType<HouseControllerL0>();

        if (houseController != null)
        {
            // Call the ResetState() method to avoid overlapping
            houseController.ResetState();
        }
        else
        {
            Debug.LogWarning("HouseControllerL0 not found in the scene.");
        }
        SceneManager.LoadScene("MainMenu");
    }
}
