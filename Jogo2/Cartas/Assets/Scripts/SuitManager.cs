using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitManager : MonoBehaviour
{
    public string suit;
    public GameObject card;
    public List<Card> cardScript = new List<Card>();
    private string currentShowingCard;
    public List<string> cardValueList;  

    private void Start()
    {
        RandomizeCards();
        InstatiateCards();
    }

    private void InstatiateCards()
    {
        Vector3 sizeCard = card.GetComponent<Renderer>().bounds.size;
        float distance = 0.1f;
        float startSpace =  transform.position.x - (((sizeCard.x + distance) * cardValueList.Capacity)/2);
        startSpace += (sizeCard.x + distance) / 2;

        for (int i = 0; i<cardValueList.Capacity; i++)
        {
            Vector3 position = new Vector3(startSpace+i*(sizeCard.x + distance), transform.position.y, 0);
            cardScript.Add(Instantiate(card, position, Quaternion.identity, transform).GetComponent<Card>());
            cardScript[i].SetCard(cardValueList[i], suit);
        }

    }

    private void RandomizeCards()
    {
        string temp;
        for (int i = 0; i< cardValueList.Capacity; i++)
        {
            int n = Random.Range(0, cardValueList.Capacity);
            temp = cardValueList[i];
            cardValueList[i] = cardValueList[n];
            cardValueList[n] = temp;
        }
    }

    public void SetAllCards()
    {
        foreach (Card c in cardScript)
        {
            c.SetDownCard();
        }
    }

    public void ClearCards(string s)
    {
        foreach (Card c in cardScript)
        {
            c.Delete(s);
        }
    }
}
