
using System.Collections.Generic;

public class Player
{
    public List<Card> playerHand = new List<Card>();
    string specials;
    public string name;

    bool PlayerHasSpecial()
    {
        if (specials != ""){return true;}else{return false;}
    }

}
    

