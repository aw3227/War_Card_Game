
public class Card
{
    public string Suit { get; set; }
    public int Number { get; set; }
    public string CardName { get; set; }


    /// <summary>
    /// Constructor for Card Class requiring a number and suit. Additionally, the number and suit are used by CardNameCreate method to create a unique name for each card
    /// </summary>
    public Card(int number, string suit)
    {
        this.Number = number;
        this.Suit = suit;
        this.CardName = CardNameCreate();
    }


    /// <summary>
    /// Converts values 11-14 into Jack-Ace and then returns a string that will be set to the CardName attribute
    /// </summary>
    /// <returns> A string combining card number and suit </returns>
    public string CardNameCreate()
    {
        string cardValue;

        switch (this.Number)
        {
            case 11:
                cardValue = "Jack";
                break;
            case 12:
                cardValue = "Queen";
                break;
            case 13:
                cardValue = "King";
                break;
            case 14:
                cardValue = "Ace";
                break;
            default:
                cardValue = this.Number.ToString();
                break;
        }

        return cardValue + " of " + this.Suit;
    }
}
