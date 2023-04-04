using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller
{
    public enum Result
    {
        Win,
        Tie,
        Lose,
    }

    public class Player
    {
        public List<Hand> Hands { get; }
        private Game _game;
        public bool Playing { get; set; } = true;
        public int Money { get; private set; }

        public Player(Game game, int money = 20) 
        {
            Hands = new List<Hand>
            {
                new Hand(),
            };
            _game = game;
            Money = money;
        }

        public void Hit(Hand hand)
        {
            hand.AddCard(_game.DealCard());
            CheckPlaying();
        }

        public void Stand(Hand hand)
        {
            hand.Playable = false;
        }

        public void Collect()
        {
            foreach (Hand hand in Hands)
            {
                Money += hand.Bet;
            }
        }

        public void Bet(int bet)
        {
            Hands[0].Bet = bet;
            Money -= bet;
        }

        private void CheckPlaying()
        {
            if (Hands.Where(hand => hand.Playable == true).Count() == 0)
            {
                Playing = false;
            }
        }
    }
}
