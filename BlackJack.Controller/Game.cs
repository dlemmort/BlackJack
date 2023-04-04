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
            return _shoe.TakeCard();
        }

        public void CollectBet(Hand hand)
        {
            hand.PayBet();
        }

        public void Pay(Hand hand)
        {
            int payment = hand.Bet;
            hand.CollectPayment(payment);
        }

        public void ShuffleShoe()
        {
            _shoe.Shuffle();
        }
    }
}
