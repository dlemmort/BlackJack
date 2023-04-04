using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller.Tests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void BetCollect_HandBetIs0()
        {
            // assign
            Game game = new Game(20);
            Hand hand = new Hand();
            hand.PlaceBet(3);

            // act
            game.CollectBet(hand);

            // assert
            Assert.AreEqual(0, hand.Bet);
        }

        [TestMethod]
        public void DoublePay_InitHandBet3_Makes6()
        {
            // assign
            Game game = new Game(20);
            Hand hand = new Hand();
            hand.PlaceBet(3);

            // act
            game.Pay(hand);

            // assert
            Assert.AreEqual(6, hand.Bet);
        }

        [TestMethod]
        public void DealCard_ReturnsACard()
        {
            // assign
            Game game = new Game(20);
            Hand hand = new Hand();

            // act
            Card card = game.DealCard();

            // assert
            Assert.IsInstanceOfType(card, typeof(Card));
        }
        
    }
}
