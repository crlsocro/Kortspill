using System;

public class Card
{
    //All card attributes or properties
    public Suit suit;
    public Rank rank;
    public Specialty specialty;

    //Card constructor
    public Card(Suit suit, Rank rank, Specialty specialty)
    {
        this.suit = suit;
        this.rank = rank;
        this.specialty = specialty;
    }

    //We found enums to work well here and looks cooler than lists or arrays
    public enum Suit{
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }

    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public enum Specialty
    {
        None,
        Vulture,
        Bomb,
        Quarantine,
        Joker
    }

    //Function to display the card
    override public string ToString()
    {
         return rank + " of " + suit;
    }
}
