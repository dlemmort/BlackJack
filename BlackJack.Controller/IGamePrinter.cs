using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller
{
    public interface IGamePrinter
    {
        public int GetBet(int money);
        public string GetHitOrStand(Dealer dealer, Player player);
        public void PrintInvalidChoice(string choice);
        public bool EndGame(Dealer dealer, Player player, Result result, int bet);
        public void SayThankYou();
    }
}
