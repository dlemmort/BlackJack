using BlackJack.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.UI
{
    public class GamePrinter : IGamePrinter
    {


        public int GetBet(int money)
        {
            Console.WriteLine($"Player has {money} money");
            Console.Write("Place your bet (1-10) ");
            
            int bet = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return bet;
        }

        public string GetHitOrStand(Dealer dealer, Player player)
        {
            PrintDealer(dealer);
            PrintPlayer(player);

            Console.Write("(H)it or (S)tand?");
            string choice = Console.ReadLine();
            return choice;
        }

        public void PrintInvalidChoice(string choice)
        {
            Console.WriteLine($"{choice} is not a valid option, please try again");
        }

        public bool EndGame(Dealer dealer, Player player, Result result,int bet)
        {
            PrintDealer(dealer);
            PrintFinalPlayer(player, result, bet);
            return PlayAgain();
        }

        private bool PlayAgain()
        {
            Console.Write("Do you want to keeep playing (Y)es of (N)o? ");
            string choice = Console.ReadLine();
            
            if (choice != "Y" && choice != "N")
            {
                Console.WriteLine($"{choice} is not a valid option, please answer (Y)es or (N)o.");
                PlayAgain();
            }

            if (choice == "N") return false;
            else return true;
        }

        private void PrintPlayer(Player player)
        {
            Console.WriteLine("Player has");
            foreach (Card card in player.Hands[0].Cards)
            {
                Console.WriteLine($"        {card.Rank} of {card.Suit}");
            }
            Console.WriteLine($"        Hand Value is {player.Hands[0].TotalValue}");
            Console.WriteLine($"        Bet: {player.Hands[0].Bet}");
        }

        private void PrintFinalPlayer(Player player, Result result, int bet)
        {
            Console.WriteLine("Player has");
            foreach (Card card in player.Hands[0].Cards)
            {
                Console.WriteLine($"        {card.Rank} of {card.Suit}");
            }

            switch (result)
            {
                case Result.Win:
                    Console.WriteLine($"        Hand Value is {player.Hands[0].TotalValue} -> Player wins");
                    break;
                case Result.Tie:
                    Console.WriteLine($"        Hand Value is {player.Hands[0].TotalValue} -> Tie");
                    break;
                case Result.Lose:
                    Console.WriteLine($"        Hand Value is {player.Hands[0].TotalValue} -> Player busted");
                    break;

            }
            Console.WriteLine($"        Bet: {bet}");
            Console.WriteLine();
            Console.WriteLine($"Player has {player.Money} money");
        }


        private void PrintDealer(Dealer dealer)
        {
            Console.WriteLine("Dealer has");

            for (int cardIndex = 1; cardIndex < dealer.Hand.Cards.Count; cardIndex++)
            {
                Console.WriteLine($"        {dealer.Hand.Cards[cardIndex].Rank} of {dealer.Hand.Cards[cardIndex].Suit}");
            }

            if (dealer.FirstCardVisible)
            {
                Console.WriteLine($"        {dealer.Hand.Cards[0].Rank} of {dealer.Hand.Cards[0].Suit}");
            }
            else
            {
                Console.WriteLine($"        ## Face Down ##");
            }

        }

        public void SayThankYou()
        {
            Console.WriteLine("Thanks for playing BlackJack today!");
        }
    }
}
