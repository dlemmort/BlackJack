using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller
{
    public class Dealer
    {
        private Game _game;
        public bool Playing { get; private set; }
        public bool FirstCardVisible { get; private set; } = false;
        public int TotalValue { get; private set; }
        public Hand Hand { get; private set; }
        public Dealer(Game game) 
        {
            _game = game;
            Playing = true;
            Hand = new Hand();
            GetCard(_game.DealCard());
            GetCard(_game.DealCard());
        }

        public void GetCard(Card card)
        {
            Hand.AddCard(_game.DealCard());
        }

        public void MakeFirstCardVisible()
        {
            FirstCardVisible = true;
        }

        public void TakeCard()
        {
            if (Hand.TotalValue < 17)
            {
                GetCard(_game.DealCard());
            }
            else
            {
                Playing = false;
            }
        }

    }
}
