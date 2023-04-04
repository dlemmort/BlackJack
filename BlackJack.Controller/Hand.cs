using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller
{
    public class Hand
    {
        public int TotalValue { get; private set; }
        public int Bet { get; private set; }
        public List<Card> Cards { get; private set; }
        public bool Playable { get; set; }
        public Hand() 
        { 
            TotalValue = 0;
            Bet = 0;
            Cards = new List<Card>();
            Playable = true;
        }
        
        public void AddCard(Card card)
        {
            Cards.Add(card);
            CalculateTotalValue();
        }

        private void CalculateTotalValue()
        {
            TotalValue = Cards.Sum(card => card.Value);
            if (TotalValue > 21)
            {
                int numberOfAces = Cards.Count(card => card.Rank == Rank.Ace);
                if (numberOfAces > 0)
                {
                    for (int i = 0; i < numberOfAces; i++)
                    {
                        if(TotalValue > 21)
                        {
                            TotalValue -= 10;
                        }
                    }
                }
                CheckPlayable();
                
            }
        }

        private void CheckPlayable()
        {
            if (TotalValue > 21) Playable = false;
        }

        public void PlaceBet(int bet)
        {
            Bet = bet;
        }

        public int PayBet()
        {
            int bet = Bet;
            Bet = 0;
            return bet;
        }

        public void CollectPayment(int payment)
        {
            Bet += payment;
        }


    }
}
