using System;
using System.Collections.Generic;
using System.Linq;


class Deck
{
    private Stack<Card> deck = new Stack<Card>();

    private Random randomize = new Random();

    private string[] suits = { "Spades", "Clubs", "Hearts", "Diamonds" };


    /// <summary>
    /// Build a deck of cards with values starting at 2. values 11-14 will correspond to Jack -> Ace
    /// </summary>
    public void DeckBuilder()
    {
        foreach (string suit in this.suits)
        {
            for (int number = 2; number < 15; number++)
            {
                Card card = new Card(number, suit);
                this.deck.Push(card);
            }
        }
    }

    /// <summary>
    /// Use the OrderBy and Random.Next methods together to effectively shuffle the deck
    /// Order the existing cards in ascending order according to a randomly generated key
    /// </summary>
    public void Shuffle()
    {
        this.deck = new Stack<Card>(this.deck.OrderBy(x => this.randomize.Next()));
    }


    /// <summary>
    /// Pop off a card from the deck stack to deal cards to players
    /// </summary>
    /// <returns>One Card from the deck</returns>
    public Card Deal()
    {
        return this.deck.Pop();
    }
}
