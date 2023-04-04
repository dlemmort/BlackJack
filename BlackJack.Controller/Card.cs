namespace BlackJack.Controller
{
    public enum Suit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs,
    }

    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
    }

    public record Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public int Value { get; private set; }

        public Card(Suit suit, Rank rank) 
        { 
            Suit = suit;
            Rank = rank;
            Value = AssignValue();
        }

        private int AssignValue() => Rank switch
        {
            Rank.Two => 2,
            Rank.Three => 3,
            Rank.Four => 4,
            Rank.Five => 5,
            Rank.Six => 6,
            Rank.Seven => 7,
            Rank.Eight => 8,
            Rank.Nine => 9,
            Rank.Ten => 10,
            Rank.Jack => 10,
            Rank.Queen => 10,
            Rank.King => 10,
            Rank.Ace => 11,
        };

        public void LowerAce()
        {
            Value = 1;
        }
    }
}