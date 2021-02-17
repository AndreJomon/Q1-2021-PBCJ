using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    private char currentLetter; //current showing letter
    private bool correct = false;
    [SerializeField] private char targetLetter; //correct letter
    static List<char> givenChars = new List<char>(){'2', '\'', ' ', '-', '.', ':', 'É'}; //Problematic chars in Pokémon names
    private void Awake()
    {
        UpdateCurrentLetter('?');
    }
    public void CreateLetter(char c)
    {
        targetLetter = c;
        if (givenChars.Contains(c))
        {
            CheckLetter(c);
        }
    }

    /// <summary>
    /// If the letter c is correct and was not already put, return true
    /// </summary>s
    /// <param name="c"></param>
    /// <returns></returns>
    public bool CheckLetter(char c)
    {
        if (!correct)
        {
            if (c == targetLetter)
            {
                correct = true;
                UpdateCurrentLetter(c);
                return true;
            }
            return false;
        }
        return false;
    }

    /// <summary>
    /// Return if the letter is correct or not
    /// </summary>
    /// <returns></returns>
    public bool CheckLetter()
    {
        return correct;
    }

    /// <summary>
    /// Update letter for the char
    /// </summary>
    /// <param name="c"></param>
    private void UpdateCurrentLetter(char c)
    {
        currentLetter = c;
        GetComponent<Text>().text = currentLetter.ToString();
    }

}
