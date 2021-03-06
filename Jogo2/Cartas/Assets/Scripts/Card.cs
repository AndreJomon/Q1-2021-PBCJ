using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private bool cardRevealed = false;
    public string card;   //Value of this card A   Ace, 2, 3..., Jack, Queen, King
    public string suit;  //Type of the suit  diamonds, spades, clubs, hearts
    private Sprite frontCard;
    public Sprite backCard;

    void Start()    
    {
        GetRender();
        UpdateFaceUp();
    }

    public string GetCard()
    {
        return card.ToLower() + "_of_" + suit;
    }

    public void GetRender()
    {
        string temp = GetCard();
        frontCard = Resources.Load<Sprite>("cartas/" + temp);
    }

    public void SetCard(string card, string suit)
    {
        this.card = card;
        this.suit = suit;
    }

    public bool FlipCard()
    {
        cardRevealed = !cardRevealed;

        UpdateFaceUp();

        return cardRevealed;
    }

    private void UpdateFaceUp()
    {
        if (cardRevealed)
        {
            GetComponent<SpriteRenderer>().sprite = frontCard;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = backCard;
        }
    }

    public void SetDownCard()
    {
        if (cardRevealed)
        {
            FlipCard();
        }
    }

    public void Delete(string s)
    {
        if (s.ToLower() == card.ToLower())
        {
            Destroy(gameObject);
        }
    }

    public void OnMouseDown()
    {
        if (TableManager.instance.CheckSuitsClicked().Contains(suit))
        {
            SoundEffects.instance.PlayWrong();
        } else
        {
            FlipCard();
            TableManager.instance.AddCardToChoice(card, suit);
        }
    }
}
