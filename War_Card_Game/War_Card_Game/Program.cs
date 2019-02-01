using System;

class Program
{
    /// <summary>
    /// The main method contains multiple while loops allowing the Generals to choose when to end a war and whether to wage war again once a war has ended
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {

        bool StillPlaying = true;

       
        ///first while loop which starts a new war if the Generals choose to do so after the end of a war
        while (StillPlaying)
        {

            bool WarOver = false;

            Console.WriteLine("Enter the name of the first army General: ");
            string GeneralName1 = Console.ReadLine();
            Console.WriteLine("Enter the name of the second army General: ");
            string GeneralName2 = Console.ReadLine();

            War war = new War(GeneralName1, GeneralName2);
            

            ///second while loop that continues the game until one General wins or a truce is agreed upon
            while (!WarOver)
            {

                if (war.Counter > 500)
                {
                    Console.WriteLine("Generals, you have been waging war for " + war.Counter.ToString() + " battles. You may want to declare a truce. Type \"yes\" to continue the war: ");
                }
                else
                {
                    Console.WriteLine("Please type \"yes\" if you would you like to continue the war: ");
                }

                Console.WriteLine("Type anything else to end the war and declare a truce");
                string play = Console.ReadLine();


                if (play == "yes" || play == "\"yes\"")
                {
                    bool Proceed = false;
                    int BattlesFought = 0;
                    Console.WriteLine("How many battles are you willing to fight? ");


                    ///third while loop which requires input for battles fought to be a number between 1-10,000
                    while (!Proceed)
                    {
                        string inputString = Console.ReadLine();
                        bool Parsed = Int32.TryParse(inputString, out BattlesFought);

                        if (!Parsed)
                            Console.WriteLine("'{0}' is not a valid number. Please enter a new number", inputString);
                        else if (Parsed)
                        {
                            BattlesFought = Int32.Parse(inputString);
                            if (BattlesFought > 10000 || BattlesFought < 1)
                            {
                                Console.WriteLine("Your Leiutenant suggests waging between 1 and 10,000 battles. '{0}' battles would be ridiculous", inputString);
                            }
                            else
                            {
                                Proceed = true;
                            }
                        }

                    }
                    
                    Console.WriteLine();


                    for (int turn = 0; turn < BattlesFought; turn = turn + 1)

                    {
                        war.Battle();
                        WarOver = war.EndWar();
                        if (WarOver == true)
                        {
                            break;
                        }

                    }

                }
                else
                {
                    war.truce = true;
                    WarOver = war.EndWar();
                    if (WarOver == true)
                    {
                        break;
                    }

                }

            }

            Console.WriteLine("The War has ended. Should a new war begin?");
            Console.WriteLine("Type \"yes\" to play again or type anything else to exit");
            string PlayAgain = Console.ReadLine();


            if (PlayAgain == "yes" || PlayAgain == "\"yes\"")
            {
                continue;
            }
            else
            {
                StillPlaying = false;
            }


        }


    }


}
