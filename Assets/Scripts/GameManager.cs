using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Code code;
    Attempts attempts;
    LastHistoryAttempts lastHistoryAttempts;

    [Header("Sounds Settings")]
    [SerializeField] AudioSource wrongSound;
    [SerializeField] AudioSource correctSound;

    [Header("Texts Settings")]
    [SerializeField] Text userInputText;
    [SerializeField] Text randomCodeText;
    [SerializeField] Text SameOrExistText;
    [SerializeField] Text AttemptsText;


    [Header("Panels Settings")]
    [SerializeField] GameObject CorrectCodePanel;
    [SerializeField] GameObject HistoryPanel;
    [SerializeField] GameObject levelFailedPanel;

    [Header("Testing Settings")]
    [SerializeField] GameObject RandomCode; // This game object is ONLY FOR ME to practice the game.
    [SerializeField] bool isShown;


    int amount;
    bool isUserCodeOnlyDiffrentNumbers;


    /// ////////////////////////////////////////////
    //public int amountOfSame;
    //public int amountOfExist;

    private void Awake()
    {
        code = FindObjectOfType<Code>();
        attempts = FindObjectOfType<Attempts>();
        lastHistoryAttempts = FindObjectOfType<LastHistoryAttempts>();
    }

    private void Start()
    {
       // Screen.orientation = ScreenOrientation.Portrait;
        amount = attempts.amountOfAttemps;
        AttemptsText.text = "ATTEMPTS: " + amount;
        isShown = false; // Just For Practice!

    }

    private void Update()
    {
        PlayerFail();
    }

    // Restart The Game
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Quitting The Game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting...");
    }

    // If the player doesn't want to replay
    public void NoContinueButton()
    {
        
    }

    // Open The history panel
    public void OpenHistoryPanel()
    {
        HistoryPanel.SetActive(true);
    }

    // Close the history panel and comeback to the game.
    public void CloseHistoryPanel()
    {
        HistoryPanel.SetActive(false);
    }

    // Back to the Main Menu -> the place where the player can choose his number of attempts.
    public void ToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // This funcion is ONLY FOR ME to practice the game. Not gonna show in the game itself !!
    public void ShowCode() 
    {
        if (isShown == false)
        {
            RandomCode.SetActive(false);
            isShown = true;

        } else
        {
            RandomCode.SetActive(true);
            isShown = false;
        }

    }

    // Checks if the player has run out of attempts.
    void PlayerFail()
    {
        if (amount == 0)
        {
            levelFailedPanel.SetActive(true);
        }
    }


    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ///

    bool HasRepeatedDigits(int userCode)
    {
        int[] digitCountArray = new int[10];
        int checkLastDigit = userCode % 10;

        while (userCode > 0)
        {
            digitCountArray[checkLastDigit]++;

            if (digitCountArray[checkLastDigit] > 1 )
            {
                return true;
            }

            userCode /= 10;
            checkLastDigit = userCode % 10;
        }
        return false;
    }

    // The funcion below is that run when we push on the ENTER BUTTON.
    public void CheckIfCodesMatch() 
    {
        int userCodeNumber = int.Parse(userInputText.text);
        bool hasUserRepeatedDigits = HasRepeatedDigits(userCodeNumber);

        // We can check the player code only when he puts 4 digits, And all of them are diffrent
        if (code.codeIndex == 4 && !hasUserRepeatedDigits)
        {
            // If the code correct.
            if (userInputText.text == randomCodeText.text)
            {
                correctSound.Play();
                CorrectCodePanel.SetActive(true);
            }

            // If the code wrong.
            else
            {
                wrongSound.Play();
                amount--;
                AttemptsText.text = "ATTEMPTS: " + amount;
                lastHistoryAttempts.AddInputToHistory();
                lastHistoryAttempts.AddSameOrExistHistory();
                code.ResetCode(); 
            }
        } 
        else
        {
            Debug.Log("You need 4 digits AND they all have to be different!");
        }
    }

 }

