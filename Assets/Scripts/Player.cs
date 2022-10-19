using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ScriptableObject
{
    public string Name;
    public Player NextPlayer;
    public List<Card> Hand;
    
    public Player()
    {
        //Hack for now, until deal implemented
        Hand.Add(new Card(Value.Ace, Suit.Club));
        Hand.Add(new Card(Value.Ace, Suit.Diamond));
        Hand.Add(new Card(Value.Ace, Suit.Heart));
        Hand.Add(new Card(Value.Ace, Suit.Spade));
        Hand.Add(new Card(Value.Queen, Suit.Heart));
    }

    public static bool AskToOrderTrump(Card upturnedCard)
    {
        //Eventually add logic for computer to determine if ordering
        Debug.Log($"Order up {upturnedCard.Print()}?");
        return ReadOrder();
    }

    private static bool ReadOrder()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Y was selected");
            return true;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Y was selected");
            return false;
        }
        return false;
    }
}
