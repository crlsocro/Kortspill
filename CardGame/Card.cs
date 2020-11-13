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

    public Enum GetSuitAndRank(Card card)
    {
        return card.suit;
    }

    public string ToString(Card card)
    {
        return card.rank + " of " + card.suit;
    }
}
