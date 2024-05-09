using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void LoadL0()
    {
        SceneManager.LoadScene("Level0");
    }
    public void LoadL1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
