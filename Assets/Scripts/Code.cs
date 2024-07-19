using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code : MonoBehaviour
{

    [SerializeField] Text playerCode;               // Refrence to the player code.
    [SerializeField] string code = null;            // At start - the code is null. Its empty.
    public int codeIndex = 0;                       // At start - we dont have a code. So the code index is 0. Complete code is codeIndex 4.


    public void CodeFuncion(string codeDigits)
    {
        // This funcion happend ONLY when we have less than 4 digits in our code.
        if (codeIndex < 4)
        {
            codeIndex++;
            code += codeDigits;         //.ToString();
            playerCode.text = code;
        }
       
    }

    // This funcion reset the user code.
    public void ResetCode()
    {
        codeIndex = 0;
        code = "- - - -";
        code = null;
        playerCode.text = code;
    }

    // This funcion delete the last digit.
    public void DeleteDigit()
    {
        codeIndex--;
        code = code.Remove(playerCode.text.Length - 1);
        playerCode.text = code;
    }

    // The funcion that check if the code is true (ENTER BUTTON) is on GameManager script.
}


