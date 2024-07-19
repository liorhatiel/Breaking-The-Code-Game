using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCode : MonoBehaviour
{

    // This code create a code that every digit in it appear ONLY ONE TIME ! 
    [SerializeField] Text randomCodeText;
    [SerializeField] int[] codeDigits = new int[4];
     
     int numberA;
     int numberB;
     int numberC;
     int numberD;
    
     int randomCodeNumber;

    void Start()
    {
        GenerateRandomNumber();
        AssignRandomNumber();
    }




    void GenerateRandomNumber()
    {
        numberA = Random.Range(1, 10);
        numberB = Random.Range(0, 10);
        numberC = Random.Range(0, 10);
        numberD = Random.Range(0, 10);

        if (numberA == numberB || numberA == numberC || numberA == numberD || numberB == numberC || numberB == numberD || numberC == numberD)
        {
            GenerateRandomNumber();
        } else
        {
            codeDigits[0] = numberA;
            codeDigits[1] = numberB;
            codeDigits[2] = numberC;
            codeDigits[3] = numberD;
        }
    }

    void AssignRandomNumber()
    {
        randomCodeText.text = numberA.ToString() + numberB.ToString() + numberC.ToString() + numberD.ToString();
    }


}
