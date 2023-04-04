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
            for (int i = 0; i < 6; i++)
            {

                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    {
                        Cards.Add(new Card(suit, rank));
                    }
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
