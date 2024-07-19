using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Attempts : MonoBehaviour
{

    public int amountOfAttemps;
  

    void Start()
    {
         amountOfAttemps = PlayerPrefs.GetInt("PlayerChosenAttempts"); // We get this value from 'MenuManager' script.
       // amountOfAttemps = 3;
    }


}
