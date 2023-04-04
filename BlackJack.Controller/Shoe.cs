using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller
{
    public class Shoe
    {
        public List<Card> Cards { get; private set; }

        public Shoe()
        {
            Cards = new List<Card>();
            AddCards();
        }

        public Card TakeCard()
        {
            Card cardToReturn = Cards[0];
            Cards.RemoveAt(0);
            return cardToReturn;
        }

        private void AddCards()
        {
            for (int deck = 0; deck < 6;  deck++)
            {
                for (int suitNumber = 0; suitNumber < 4; suitNumber++)
                {
                    Suit suit = new Suit();
                    switch (suitNumber)
                    {
                        case 0: suit = Suit.Hearts; break;
                        case 1: suit = Suit.Diamonds; break;
                        case 2: suit = Suit.Clubs; break;
                        case 3: suit = Suit.Spades; break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                    Cards.Add(new Card(suit, Rank.Two));
                    Cards.Add(new Card(suit, Rank.Three));
                    Cards.Add(new Card(suit, Rank.Four));
                    Cards.Add(new Card(suit, Rank.Five));
                    Cards.Add(new Card(suit, Rank.Six));
                    Cards.Add(new Card(suit, Rank.Seven));
                    Cards.Add(new Card(suit, Rank.Eight));
                    Cards.Add(new Card(suit, Rank.Nine));
                    Cards.Add(new Card(suit, Rank.Ten));
                    Cards.Add(new Card(suit, Rank.Jack));
                    Cards.Add(new Card(suit, Rank.Queen));
                    Cards.Add(new Card(suit, Rank.King));
                    Cards.Add(new Card(suit, Rank.Ace));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = Cards.Count-1; i > 0; i--)
            {
                int randomInt = random.Next(0, i);
                Card tempCard = Cards[i];
                Cards[i] = Cards[randomInt];
                Cards[randomInt] = tempCard;
            }
        }

    }
}
