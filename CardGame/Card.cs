using System;

public class Card
{
    public Suit suit;
    public Rank rank;

    public Card(Suit suit, Rank rank)
    {
        this.suit = suit;
        this.rank = rank;
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
        Vulture,
        Bomb,
        Quarantine,
        Joker
    }

    public Enum GetSuitAndRank(Card card)
    {
        return card.suit;
    }
}
