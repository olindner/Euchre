using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Suit
{
    Club, Diamond, Heart, Spade
}

public enum Value
{
    Nine, Ten, Jack, Queen, King, Ace
}

public class Card : ScriptableObject
{
    public Suit Suit;
    public Value Value;

    public Card(Value _value, Suit _suit)
    {
        Suit = _suit;
        Value = _value;
    }

    public string Print()
    {
        return $"{Value} of {Suit}";
    }
}
