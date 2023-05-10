using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void returnToLevel()
    {
        SceneManager.LoadScene("Slums_Level");
    }
}
