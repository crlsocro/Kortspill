using System;

public class Card
{
    public Suit suit;
    public Rank rank;
    public Specialty specialty;

    public Card(Suit suit, Rank rank, Specialty specialty)
    {
        this.suit = suit;
        this.rank = rank;
        this.specialty = specialty;
    }

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

    override public string ToString()
    {
        if (specialty == (Specialty)1)
        {
            return rank + " of " + suit + " special: " + specialty;
        }
        else if(specialty == (Specialty)2)
        {
            return rank + " of " + suit + " special: " + specialty;
        }
        else if (specialty == (Specialty)3)
        {
            return rank + " of " + suit + " special: " + specialty;
        }
        else if (specialty == (Specialty)4)
        {
            return rank + " of " + suit + " special: " + specialty;
        } else
        {
            return rank + " of " + suit;
        }
    }
}
