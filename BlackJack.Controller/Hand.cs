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
        public int Bet { get; set; }
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
                int aceIndex = Cards.FindIndex(card => card.Rank == Rank.Ace && card.Value == 11);
                if (aceIndex != -1)
                {
                    Cards[aceIndex].LowerAce();
                    CalculateTotalValue();
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


    }
}
