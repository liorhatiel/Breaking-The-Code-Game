using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastHistoryAttempts : MonoBehaviour
{

    [Header("Texts settings:")]
    [SerializeField] Text userInputTry;
    [SerializeField] Text userInputsHistory;
    [SerializeField] Text userSameExistHistory;
    [SerializeField] Text randomCodeText;


    public void AddInputToHistory()
    {
        userInputsHistory.text = userInputsHistory.text + '\n' + userInputTry.text;
    }

    public void AddSameOrExistHistory()
    {
        int codesLength = randomCodeText.text.Length;

        userSameExistHistory.text += '\n';
        for (int i = 0; i < codesLength; i++)
        {
            for (int j = 0; j < codesLength; j++)
            {
                if (randomCodeText.text[i] == userInputTry.text[j])
                {
                    if (j == i)
                    {
                        Debug.Log("Same");
                         userSameExistHistory.text += "S ";
                    }
                    else
                    {
                        Debug.Log("Exist");
                         userSameExistHistory.text += "E ";
                    }
                }
            }
        }

    }
}

