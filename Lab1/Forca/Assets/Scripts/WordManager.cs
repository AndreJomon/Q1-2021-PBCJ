using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public TextAsset textArchive;
    private List<string> words = new List<string>();
    [SerializeField] private string selectedWord;
    public GameObject letter;
    private List<GameObject> letters = new List<GameObject>();

    private void Start()
    {
        ReadTxt();
        selectedWord = WordSelector().ToUpper();
        GameManager.instance.SetChosenWord(selectedWord);
        SetLetters(selectedWord);
    }

    /// <summary>
    /// Selector of wort at random
    /// </summary>
    /// <returns></returns>
    private string WordSelector()
    {
        return words[Random.Range(0, words.Count - 1)];
    }

    /// <summary>
    /// Create the word in the UI and get the references
    /// </summary>
    /// <param name="word"></param>
    private void SetLetters(string word)
    {
        char[] cLetters = word.ToCharArray();
        foreach (char c in cLetters)
        {
            GameObject l = Instantiate(letter, transform);
            l.GetComponent<Letter>().CreateLetter(c);
            letters.Add(l);
        }
    }

    /// <summary>
    /// Do a check if any letter is the same as C. If some was the same, return true
    /// </summary>
    /// <param name="c">Character to test</param>
    /// <returns></returns>
    public bool InputLetter(char c)
    {
        bool result = false;
        foreach (GameObject letter in letters)
        {
            result = letter.GetComponent<Letter>().CheckLetter(char.ToUpper(c)) || result;
        }

        return result;
    }

    public bool CorrectWord()
    {
        bool result = true;
        foreach (GameObject letter in letters)
        {
            result = letter.GetComponent<Letter>().CheckLetter() && result;
        }

        return result;
    }

    /// <summary>
    /// Read text from the archive, separation with backspace
    /// </summary>
    private void ReadTxt()
    {
        string path = "Assets/Resources/PokemonList.txt";
        StreamReader reader = new StreamReader(path);

        string s;

        while ((s = reader.ReadLine()) != null) {
            words.Add(s);
        }
        reader.Close();
    }
}
