using System.Collections.Generic;

public class General
{
    public string Name { get; set; }
    public Queue<Card> Cards = new Queue<Card>();


    /// <summary>
    /// Constructor for General Class requiring a name parameter
    /// </summary>
    /// <param name="name"></param>
    public General(string name)
    {
        this.Name = name;
    }
}

