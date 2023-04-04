using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller.Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Constructor_InitialPlayerHasOneHand()
        {
            // assign
            Game game = new Game();
            Player player = new Player(game);

            // act
            int numberOfHands = player.Hands.Count();

            // assert
            Assert.AreEqual(1, numberOfHands);
        }

        [TestMethod]
        public void Hit_AddsOneCardToHand()
        {
            // assign
            Game game = new Game();
            Player player = new Player(game);

            // act
            player.Hit(player.Hands[0]);

            // assert
            Assert.AreEqual(1, player.Hands[0].Cards.Count());
        }

        [TestMethod]
        public void Stand_SetsHandPlayableToFalse()
        {
            // assert
            Game game = new Game();
            Player player = new Player(game);

            // act
            player.Stand(player.Hands[0]);

            // assert
            Assert.IsFalse(player.Hands[0].Playable);
        }

        [TestMethod]
        public void Constructor_InitialPlayerHas20Money()
        {
            //assert
            Game game = new Game();
            Player player = new Player(game);

            // act
            int money = player.Money;

            // assert
            Assert.AreEqual(20, money);
        }

        [TestMethod]
        public void Collect_WithBet5AndMoney20_MoneyStays20()
        {
            // assert
            Game game = new Game();
            Player player = new Player(game,20);
            player.Bet(5);

            // act
            player.Collect();

            // assert
            Assert.AreEqual(20, player.Money);
        }

        [TestMethod]
        public void Bet_Bet5AndMoney20_MoneyBecomes15()
        {
            // assert
            Game game = new Game();
            Player player = new Player(game, 20);
            
            //act
            player.Bet(5);

            // assert
            Assert.AreEqual(15, player.Money);
        }
    }
}
