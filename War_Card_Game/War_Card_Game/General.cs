using System.Collections.Generic;

public class General
{
    public string name { get; set; }
    public Queue<Card> cards = new Queue<Card>();


    /// <summary>
    /// Constructor for General Class requiring a name parameter
    /// </summary>
    /// <param name="name"></param>
    public General(string name)
    {
        this.name = name;
    }
}

