using System;
using System.Collections.Generic;


public class War
{
    public General General1;
    public General General2;
    public int Counter;
    public bool truce = false;


    /// <summary>
    /// Constructor taking two strings and setting them to each General's name before creating a deck, shuffling it and dealing 26 cards/troops to each General
    /// </summary>
    public War(string GeneralName1, string GeneralName2)
    {
        General1 = new General(GeneralName1);
        General2 = new General(GeneralName2);

        Deck deck = new Deck();

        deck.DeckBuilder();

        deck.Shuffle();

        while (General1.Cards.Count < 26)
        {
            General1.Cards.Enqueue(deck.Deal());
            General2.Cards.Enqueue(deck.Deal());
        }



        Console.WriteLine("General " + General1.Name + " has an army of " + General1.Cards.Count + " troops");
        Console.WriteLine("General " + General2.Name + " has an army of " + General2.Cards.Count + " troops");


    }


    /// <summary>
    /// This method contains the logic for determining if the war has ended. After each battle this method will be called.
    /// </summary>
    /// <returns>This method only returns true if a truce has been declared or if one General runs out of troops. Thus ending the war.</returns>
    public bool EndWar()
    {

        if (truce == true)
        {
            Console.WriteLine("General " + General1.Name + " and General " + General2.Name + " have declared a truce after " + Counter.ToString() + " battles");
            Console.WriteLine("General " + General1.Name + " troop count: " + General1.Cards.Count);
            Console.WriteLine("General " + General2.Name + " troop count: " + General2.Cards.Count);
            return true;
        }
        else if (General1.Cards.Count < 1)
        {
            Console.WriteLine("General " + General1.Name + " has run out of troops!\n");
            Console.WriteLine("General " + General2.Name + " has won the war!\n");
            Console.WriteLine("Battles Completed: " + Counter.ToString());
            return true;
        }
        else if (General2.Cards.Count < 1)
        {
            Console.WriteLine("General " + General2.Name + " has run out of troops!\n");
            Console.WriteLine("General " + General1.Name + " has won the war!\n");
            Console.WriteLine("Battles Completed: " + Counter.ToString());
            return true;
        }
        return false;
    }


    /// <summary>
    /// This Method contains the logic for each battle. Each General plays 1 card face up. If they are equal then the battle escalates to a war.
    /// The war requires each General to place a card face down and then a second card face up. The War continues until one General plays a higher card face up.
    /// All cards played in the initial battle and subsequent wars will be added to each Generals pool of used cards. Both pools are given to the winner.
    /// Queues are used to keep track of each Generals played card pool in order to add cards back into the winning generals deck in the order they were played.
    /// Lastly, a counter is used to keep track of how many battles have been fought and suggest when to declare a truce
    /// </summary>
    public void Battle()
    {
        Queue<Card> General1pool = new Queue<Card>();
        Queue<Card> General2pool = new Queue<Card>();

        var General1card = General1.Cards.Dequeue();
        var General2card = General2.Cards.Dequeue();

        General1pool.Enqueue(General1card);
        General2pool.Enqueue(General2card);

        Console.WriteLine("General " + General1.Name + " sends in " + General1card.CardName + " and General " + General2.Name + " sends in " + General2card.CardName + " to the battle!");

        while (General1card.Number == General2card.Number)
        {
            Console.WriteLine("Your troops are evenly matched! The Battle has escalated to War!");
            if (General1.Cards.Count < 2)
            {
                General1.Cards.Clear();
                Counter++;
                return;
            }
            if (General1.Cards.Count < 2)
            {
                General1.Cards.Clear();
                Counter++;
                return;
            }

            General1pool.Enqueue(General1.Cards.Dequeue());
            General2pool.Enqueue(General2.Cards.Dequeue());

            General1card = General1.Cards.Dequeue();
            General2card = General2.Cards.Dequeue();

            General1pool.Enqueue(General1card);
            General2pool.Enqueue(General2card);

            Console.WriteLine("General " + General1.Name + " sends in " + General1card.CardName + " and General " + General2.Name + " sends in " + General2card.CardName + " to the battle!");

        }

        if (General1card.Number < General2card.Number)
        {
            while (General1pool.Count > 0)

            {
                General2.Cards.Enqueue(General1pool.Dequeue());
                General2.Cards.Enqueue(General2pool.Dequeue());
            }

            Console.WriteLine("General " + General2.Name + " has won! All troops from the battle have joined their army!");
            Console.WriteLine("General " + General1.Name + " troop count: " + General1.Cards.Count);
            Console.WriteLine("General " + General2.Name + " troop count: " + General2.Cards.Count);

        }
        else
        {
            while (General1pool.Count > 0)

            {
                General1.Cards.Enqueue(General1pool.Dequeue());
                General1.Cards.Enqueue(General2pool.Dequeue());
            }
            Console.WriteLine("General " + General1.Name + " has won! All troops from the battle have joined their army!");
            Console.WriteLine("General " + General1.Name + " troop count: " + General1.Cards.Count);
            Console.WriteLine("General " + General2.Name + " troop count: " + General2.Cards.Count);
        }

        Counter++;
        Console.WriteLine("Battle number " + Counter.ToString() + " is complete");
        Console.WriteLine();
    }
}
