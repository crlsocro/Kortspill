using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static Card;
using static CardGame.Program;

public class Deck
{
	//List
	public List<Card> theDeck = new List<Card>();

	public List<Card> CreateDeck()
	{
		//Filling the deck. Using the Card class to assign suit and rank
		for (int i = 0; i < 13; i++)
		{
			for (int j = 0; j < 4; j++)
			{
               theDeck.Add(new Card( (Card.Suit)j, (Card.Rank)i, (Card.Specialty)0 ));
			}
		}
		SelectSpecialtyCards();
		return theDeck;
	}

	void SelectSpecialtyCards()
    {
		int rndVulture = rnd.Next(0, 52);
		theDeck[rndVulture].specialty = (Specialty)1;

		int rndBomb = rnd.Next(0, 52);
        if (rndBomb != rndVulture)
        {
			theDeck[rndBomb].specialty = (Specialty)2;
		}
		else { SelectSpecialtyCards(); }

		int rndQuarantine = rnd.Next(0, 52);
		if (rndQuarantine != rndVulture || rndQuarantine != rndBomb)
		{
			theDeck[rndQuarantine].specialty = (Specialty)3;
        }
        else{SelectSpecialtyCards();}

		int rndJoker = rnd.Next(0, 52);
		if (rndJoker != rndVulture || rndJoker != rndBomb || rndJoker != rndQuarantine)
		{
			theDeck[rndJoker].specialty = (Specialty)4;
		}
		else { SelectSpecialtyCards(); }
	}
	
}
