using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableManager : MonoBehaviour
{
    [SerializeField]
    private List<SuitManager> suitManagers = new List<SuitManager>(); //Suits managers in game
    private List<string> listChoices = new List<string>(); //List of cards clicked
    private List<string> listChoicesSuits = new List<string>(); //List of suits already clicked (to not get two on the same suit)
    private int tries = 0; //Number of tries
    private int nCombinations = 0; //Number of combinations made
    private int nMaxCombinations = 13; //Number of maximum combinations (this game just use a "normal" set of cards, so hardcoded to 13
    private int maxSuits; //number of maximum suits in game

    public static TableManager instance; //Singleton
    public Text tryText; //Text of tries on this game
    public Text bestTryText; //Text of minimum tries on a game.
    public LoadScener loadScener;
    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
        } 
        
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        maxSuits = suitManagers.Capacity;
        SetBestTryText();
    }

    public bool AddCardToChoice(string cardName, string cardSuit)
    {
        if (listChoices.Count < maxSuits && !listChoicesSuits.Contains(cardSuit))
        {
            listChoices.Add(cardName);
            listChoicesSuits.Add(cardSuit);
        }

        if (listChoices.Count == maxSuits)
        {
            Tried();
            StartCoroutine(VerifyAnswer());
        }
        return false;
    }

    private IEnumerator VerifyAnswer()
    {
        
        bool correct = true;
        for (int i = 0; correct && i < (listChoices.Count - 1); i++)
        {
            correct = (listChoices[i] == listChoices[i + 1]);
        }

        yield return new WaitForSeconds(1f);

        if (correct)
        {
            SoundEffects.instance.PlayCorrect();
            foreach (SuitManager sm in suitManagers)
            {
                sm.ClearCards(listChoices[0]);
            }

            nCombinations++;
            if (nCombinations == nMaxCombinations)
            {
                GameCompleted();
            }
        }

        ClearChoiceList();
    }

    private void ClearChoiceList()
    {
        foreach (SuitManager sm in suitManagers)
        {
            sm.SetAllCards();
        }
        listChoices.Clear();
        listChoicesSuits.Clear();
    }

    private void Tried()
    {
        tries++;
        tryText.text = tries.ToString();
    }

    private void SetBestTryText()
    {
        bestTryText.text = GetBestTry().ToString();
    }

    private void GameCompleted()
    {
        if (GetBestTry() > tries)
        {
            SetBestTry(tries);
            loadScener.LoadScene("Winner");
        }
        loadScener.LoadScene("Loserr");
    }

    private int GetBestTry()
    {
        return PlayerPrefs.GetInt("Best Try" + maxSuits.ToString(), 999);
    }

    private void SetBestTry(int i)
    {
        PlayerPrefs.SetInt("Best Try" + maxSuits.ToString(), tries);
    }

    public List<string> CheckSuitsClicked()
    {
        return listChoicesSuits;
    }
}
