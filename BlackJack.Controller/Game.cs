using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller
{
    public class Game
    {
        private Shoe _shoe;
        public Player Player { get; }
        public Dealer Dealer { get; }

        public Game() : this(20)
        { }

        public Game(int money)
        {
            _shoe = new Shoe();
            ShuffleShoe();
            Player = new Player(this,money);
            Dealer = new Dealer(this);
        }

        public Card DealCard()
        {
            if (_shoe.Cards.Count == 0)
            {
                throw new ShoeIsEmptyException();
            }
            return _shoe.TakeCard();
        }

        public void CollectBet(Hand hand)
        {
            hand.Bet = 0;
        }

        public void Pay(Hand hand)
        {
            hand.Bet *= 2;
        }

        public void ShuffleShoe()
        {
            _shoe.Shuffle();
        }
    }
}
