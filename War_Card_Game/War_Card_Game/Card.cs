public class Card
{
    public string suit { get; set; }
    public int number { get; set; }
    public string cardName { get; set; }


    /// <summary>
    /// Constructor for Card Class requiring a number and suit. Additionally, the number and suit are used by CardNameCreate method to create a unique name for each card
    /// </summary>
    public Card(int number, string suit)
    {
        this.number = number;
        this.suit = suit;
        this.cardName = CardNameCreate();
    }


    /// <summary>
    /// Converts values 11-14 into Jack-Ace and then returns a string that will be set to the CardName attribute
    /// </summary>
    /// <returns> A string combining card number and suit </returns>
    public string CardNameCreate()
    {
        string cardValue;

        switch (this.number)
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
                cardValue = this.number.ToString();
                break;
        }

        return cardValue + " of " + this.suit;
    }
}
