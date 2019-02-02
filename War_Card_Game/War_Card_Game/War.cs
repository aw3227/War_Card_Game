using System;
using System.Collections.Generic;


public class War
{
    public General general1;
    public General general2;
    public int counter;
    public bool truce = false;


    /// <summary>
    /// Constructor taking two strings and setting them to each General's name before creating a deck, shuffling it and dealing 26 cards/troops to each General
    /// </summary>
    public War(string generalName1, string generalName2)
    {
        general1 = new General(generalName1);
        general2 = new General(generalName2);

        Deck deck = new Deck();

        deck.DeckBuilder();

        deck.Shuffle();

        while (general1.cards.Count < 26)
        {
            general1.cards.Enqueue(deck.Deal());
            general2.cards.Enqueue(deck.Deal());
        }



        Console.WriteLine("General " + general1.name + " has an army of " + general1.cards.Count + " troops");
        Console.WriteLine("General " + general2.name + " has an army of " + general2.cards.Count + " troops");


    }


    /// <summary>
    /// This method contains the logic for determining if the war has ended. After each battle this method will be called.
    /// </summary>
    /// <returns>This method only returns true if a truce has been declared or if one General runs out of troops. Thus ending the war.</returns>
    public bool EndWar()
    {

        if (truce == true)
        {
            Console.WriteLine("General " + general1.name + " and General " + general2.name + " have declared a truce after " + counter.ToString() + " battles");
            Console.WriteLine("General " + general1.name + " troop count: " + general1.cards.Count);
            Console.WriteLine("General " + general2.name + " troop count: " + general2.cards.Count);
            return true;
        }
        else if (general1.cards.Count < 1)
        {
            Console.WriteLine("General " + general1.name + " has run out of troops!\n");
            Console.WriteLine("General " + general2.name + " has won the war!\n");
            Console.WriteLine("Battles Completed: " + counter.ToString());
            return true;
        }
        else if (general2.cards.Count < 1)
        {
            Console.WriteLine("General " + general2.name + " has run out of troops!\n");
            Console.WriteLine("General " + general1.name + " has won the war!\n");
            Console.WriteLine("Battles Completed: " + counter.ToString());
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
        Queue<Card> general1Pool = new Queue<Card>();
        Queue<Card> general2Pool = new Queue<Card>();

        var general1Card = general1.cards.Dequeue();
        var general2Card = general2.cards.Dequeue();

        general1Pool.Enqueue(general1Card);
        general2Pool.Enqueue(general2Card);

        Console.WriteLine("General " + general1.name + " sends in " + general1Card.cardName + " and General " + general2.name + " sends in " + general2Card.cardName + " to the battle!");

        while (general1Card.number == general2Card.number)
        {
            Console.WriteLine("Your troops are evenly matched! The Battle has escalated to War!");
            if (general1.cards.Count < 2)
            {
                general1.cards.Clear();
                counter++;
                return;
            }
            if (general1.cards.Count < 2)
            {
                general1.cards.Clear();
                counter++;
                return;
            }

            general1Pool.Enqueue(general1.cards.Dequeue());
            general2Pool.Enqueue(general2.cards.Dequeue());

            general1Card = general1.cards.Dequeue();
            general2Card = general2.cards.Dequeue();

            general1Pool.Enqueue(general1Card);
            general2Pool.Enqueue(general2Card);

            Console.WriteLine("General " + general1.name + " sends in " + general1Card.cardName + " and General " + general2.name + " sends in " + general2Card.cardName + " to the battle!");

        }

        if (general1Card.number < general2Card.number)
        {
            while (general1Pool.Count > 0)

            {
                general2.cards.Enqueue(general1Pool.Dequeue());
                general2.cards.Enqueue(general2Pool.Dequeue());
            }

            Console.WriteLine("General " + general2.name + " has won! All troops from the battle have joined their army!");
            Console.WriteLine("General " + general1.name + " troop count: " + general1.cards.Count);
            Console.WriteLine("General " + general2.name + " troop count: " + general2.cards.Count);

        }
        else
        {
            while (general1Pool.Count > 0)

            {
                general1.cards.Enqueue(general1Pool.Dequeue());
                general1.cards.Enqueue(general2Pool.Dequeue());
            }
            Console.WriteLine("General " + general1.name + " has won! All troops from the battle have joined their army!");
            Console.WriteLine("General " + general1.name + " troop count: " + general1.cards.Count);
            Console.WriteLine("General " + general2.name + " troop count: " + general2.cards.Count);
        }

        counter++;
        Console.WriteLine("Battle Number " + counter.ToString() + " is complete");
        Console.WriteLine();
    }
}
