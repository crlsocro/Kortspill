using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static Card;

public class Deck
{

	public string[] players = { "Hagen", "Håkon", "Chris" };
	public List<Card> theDeck = new List<Card>();

	public List<Card> getDeck()
		{

			//Storing all the cards
			

			//Filling the deck. Using the Card class to assign suit and rank
			for (int i = 0; i < 13; i++)
			{
				for (int j = 0; j < 4; j++)
				{
                theDeck.Add(new Card((Card.Suit)j, (Card.Rank)i));
				}
			}

			return theDeck;
	}

	
}
