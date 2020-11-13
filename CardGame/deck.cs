using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static Card;

public class Deck
{

	public List<Card> theDeck = new List<Card>();

	public List<Card> createDeck()
	{

		//Storing all the cards
			

		//Filling the deck. Using the Card class to assign suit and rank
		for (int i = 0; i < 13; i++)
		{
			for (int j = 0; j < 4; j++)
			{
               theDeck.Add(new Card( (Card.Suit)j, (Card.Rank)i, (Card.Specialty)0 ));
			}
		}
		selectSpecialtyCards();
		return theDeck;
	}

	void selectSpecialtyCards()
    {

		//Rerunning the function if two are the same is a terrible solution
		Random rnd = new Random();
		int rndVulture = rnd.Next(0, 52);
		theDeck[rndVulture].specialty = (Specialty)1;

		int rndBomb = rnd.Next(0, 52);
        if (rndBomb != rndVulture)
        {
			theDeck[rndBomb].specialty = (Specialty)2;
		}
		else { selectSpecialtyCards(); }

		int rndQuarantine = rnd.Next(0, 52);
		if (rndQuarantine != rndVulture || rndQuarantine != rndBomb)
		{
			theDeck[rndQuarantine].specialty = (Specialty)3;
        }
        else{selectSpecialtyCards();}

		int rndJoker = rnd.Next(0, 52);
		if (rndJoker != rndVulture || rndJoker != rndBomb || rndJoker != rndQuarantine)
		{
			theDeck[rndJoker].specialty = (Specialty)4;
		}
		else { selectSpecialtyCards(); }
	}
	
}
