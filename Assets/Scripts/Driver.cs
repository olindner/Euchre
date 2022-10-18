using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public Player ActivePlayer;
    public Suit Trump;
    private List<Card> Deck;

    void Start()
    {
        Debug.Log("Start is called");
        Debug.Log("Damn Yohan got a DUMPY huh?");

        Player You = (Player)ScriptableObject.CreateInstance("Player");
        Player Toph = (Player)ScriptableObject.CreateInstance("Player");
        Player Sokka = (Player)ScriptableObject.CreateInstance("Player");
        Player Katara = (Player)ScriptableObject.CreateInstance("Player");

        You.NextPlayer = Toph;
        Toph.NextPlayer = Sokka;
        Sokka.NextPlayer = Katara;
        Katara.NextPlayer = You;

        //Shuffle Deck
        Deck.Add(new Card(Value.King, Suit.Club));

        ActivePlayer = You; //Eventually random or first black jack
    }

    private static void ReadKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("1 was pressed");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("2 was pressed");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("3 was pressed");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("4 was pressed");
        }
    }

    void Update()
    {
        //Shuffle
        Card upturnedCard = Deal();
        DetermineTrump(ActivePlayer, upturnedCard);
        //CirculatePlay
    }

    private Card Deal()
    {
        return Deck.First();
    }

    private void DetermineTrump(Player activePlayer, Card upturnedCard)
    {
        int count = 0;
        Card trump;
        while (count < 4)
        {
            if (Player.AskToOrderTrump(upturnedCard))
            {
                OrderTrump(upturnedCard.Suit);
                return;
            }
            activePlayer = activePlayer.NextPlayer;
            count++;
        }
        //Turn over card and allow free choice
    }

    private void OrderTrump(Suit suit)
    {
        Trump = suit;
        //Stop execution, go to play
    }
}
