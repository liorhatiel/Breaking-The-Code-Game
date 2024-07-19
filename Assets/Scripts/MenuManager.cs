using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public bool is5Attempts;
    public bool is10Attempts;

    public GameObject HowManyAttemptsPanel;

    public void OpenAttemptsPanel()
    {
        HowManyAttemptsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        HowManyAttemptsPanel.SetActive(false);
    }

    

    public void PlayerChoose5Attempts()
    {
        is5Attempts = true; // Bool true.
        PlayerPrefs.SetInt("PlayerChosenAttempts", 5); // We set the value of "PlayerChosen.." to 5.
        SceneManager.LoadScene(1); // Load the new scene.

    }

    public void PlayerChoose10Attenpts()
    {
        is10Attempts = true; // Bool true.
        PlayerPrefs.SetInt("PlayerChosenAttempts", 10); // We set the value of "PlayerChosen.." to 10.
        SceneManager.LoadScene(1); // Load the new scene.

    }
    

}
