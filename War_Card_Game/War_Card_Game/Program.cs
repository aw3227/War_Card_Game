using System;

class Program
{
    /// <summary>
    /// The main method contains multiple while loops allowing the Generals to choose when to end a war and whether to wage war again once a war has ended
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {

        bool stillPlaying = true;

       
        ///first while loop which starts a new war if the Generals choose to do so after the end of a war
        while (stillPlaying)
        {

            bool warOver = false;

            Console.WriteLine("Enter the name of the first army General: ");
            string generalName1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second army General: ");
            string generalName2 = Console.ReadLine();

            War war = new War(generalName1, generalName2);
            

            ///second while loop that continues the game until one General wins or a truce is agreed upon
            while (!warOver)
            {

                if (war.counter > 500)
                {
                    Console.WriteLine("Generals, you have been waging war for " + war.counter.ToString() + " battles. You may want to declare a truce. Type \"yes\" to continue the war: ");
                }
                else
                {
                    Console.WriteLine("Please type \"yes\" if you would you like to continue the war: ");
                }

                Console.WriteLine("Type anything else to end the war and declare a truce");
                string play = Console.ReadLine();


                if (play == "yes" || play == "\"yes\"")
                {
                    bool proceed = false;
                    int battlesFought = 0;
                    Console.WriteLine("How many battles are you willing to fight? ");


                    ///third while loop which requires input for battles fought to be a number between 1-10,000
                    while (!proceed)
                    {
                        string inputString = Console.ReadLine();
                        bool parsed = Int32.TryParse(inputString, out battlesFought);

                        if (!parsed)
                            Console.WriteLine("'{0}' is not a valid number. Please enter a new number", inputString);
                        else if (parsed)
                        {
                            battlesFought = Int32.Parse(inputString);
                            if (battlesFought > 10000 || battlesFought < 1)
                            {
                                Console.WriteLine("Your Leiutenant suggests waging between 1 and 10,000 battles. '{0}' battles would be ridiculous", inputString);
                            }
                            else
                            {
                                proceed = true;
                            }
                        }

                    }
                    
                    Console.WriteLine();


                    for (int turn = 0; turn < battlesFought; turn = turn + 1)

                    {
                        war.Battle();
                        warOver = war.EndWar();
                        if (warOver == true)
                        {
                            break;
                        }

                    }

                }
                else
                {
                    war.truce = true;
                    warOver = war.EndWar();
                    if (warOver == true)
                    {
                        break;
                    }

                }

            }

            Console.WriteLine("The War has ended. Should a new war begin?");
            Console.WriteLine("Type \"yes\" to play again or type anything else to exit");
            string playAgain = Console.ReadLine();


            if (playAgain == "yes" || playAgain == "\"yes\"")
            {
                continue;
            }
            else
            {
                stillPlaying = false;
            }


        }


    }


}
