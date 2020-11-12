
using System.Collections.Generic;

public class Player
{
    public List<Card> playerHand = new List<Card>();
    string specials;

    bool PlayerHasSpecial()
    {
        if (specials != ""){return true;}else{return false;}
    }

    public string ToString(Card card)
    {
        return card.rank + " of " + card.suit;
    }

}
    

