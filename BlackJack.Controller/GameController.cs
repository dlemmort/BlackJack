using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller
{
    public class GameController
    {
        private Game _game;
        private IGamePrinter _printer;
        public GameController(IGamePrinter gamePrinter) 
        {
            _printer = gamePrinter;
        }

        public void StartGame(int money)
        {
            _game = new Game(money);
            _game.ShuffleShoe();

            PlaceBets();

            _game.Player.Hands[0].AddCard(_game.DealCard());
            _game.Player.Hands[0].AddCard(_game.DealCard());

            while (_game.Player.Playing || _game.Dealer.Playing)
            {
                PlayRound();
            }

            EndGame();
        }

        private void PlaceBets()
        {
            int bet = _printer.GetBet(_game.Player.Money);
            _game.Player.Bet(bet);
            
        }

        private void PlayRound()
        {
            if (_game.Player.Playing)
            {
                string choice = _printer.GetHitOrStand(_game.Dealer, _game.Player);

                switch (choice)
                {
                    case "H":
                        _game.Player.Hit(_game.Player.Hands[0]);
                        break;
                    case "S":
                        _game.Player.Stand(_game.Player.Hands[0]);
                        break;
                    default:
                        _printer.PrintInvalidChoice(choice);
                        break;
                }
            }

            _game.Dealer.TakeCard();
        }

        private void EndGame()
        {
            _game.Dealer.MakeFirstCardVisible();
            bool playagain = false;
            int playerBet = _game.Player.Hands[0].Bet;

            //Player loses
            if (_game.Player.Hands[0].TotalValue > 21 || (_game.Player.Hands[0].TotalValue < _game.Dealer.Hand.TotalValue && _game.Dealer.Hand.TotalValue <= 21))
            {
                _game.CollectBet(_game.Player.Hands[0]);
                _game.Player.Collect();
                playagain = _printer.EndGame(_game.Dealer, _game.Player, Result.Lose, playerBet);
            }

            //Tie
            else if (_game.Player.Hands[0].TotalValue == _game.Dealer.Hand.TotalValue)
            {
                _game.Player.Collect();
                playagain = _printer.EndGame(_game.Dealer, _game.Player, Result.Tie, playerBet);
            }
            //Player wins
            else
            {
                _game.Pay(_game.Player.Hands[0]);
                _game.Player.Collect();
                playagain = _printer.EndGame(_game.Dealer, _game.Player, Result.Win, playerBet);

            }

            if (playagain)
            {
                StartGame(_game.Player.Money);
            }
            else
            {
                _printer.SayThankYou();
            }
        }

    }
}
