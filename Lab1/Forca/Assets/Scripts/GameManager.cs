using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string chonseWord = ""; //Word selected

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(this);
            return;
        }
    }

    public void SetChosenWord(string s)
    {
        chonseWord = s;
    }

    public string GetChosenWord()
    {
        return chonseWord;
    }

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    }
}
