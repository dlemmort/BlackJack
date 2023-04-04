using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller.Tests
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void Constructor_InitialValueIs0()
        {
            // assign
            Hand hand = new Hand();

            // act
            int totalValue = hand.TotalValue;

            // assert
            Assert.AreEqual(0, totalValue);
        }

        [TestMethod]
        public void CalculateTotalValue_HeartsFiveSpadesQueenIs15()
        {
            // assign
            Card firstCard = new Card(Suit.Hearts, Rank.Five);
            Card secondCard = new Card(Suit.Spades, Rank.Queen);
            Hand hand = new Hand();

            // act
            hand.AddCard(firstCard);
            hand.AddCard(secondCard);

            // assert
            Assert.AreEqual(15,hand.TotalValue);
        }

        [TestMethod]
        public void CalculateTotalValue_TwoAcesIs12()
        {
            // assign
            Card firstCard = new Card(Suit.Hearts, Rank.Ace);
            Card secondCard = new Card(Suit.Spades, Rank.Ace);
            Hand hand = new Hand();

            // act
            hand.AddCard(firstCard);
            hand.AddCard(secondCard);

            // assert
            Assert.AreEqual(12,hand.TotalValue);
        }

        [TestMethod]
        public void CalculateTotalValue_FourAcesIs14()
        {
            // assign
            Card firstAce = new Card(Suit.Hearts, Rank.Ace);
            Card secondAce = new Card(Suit.Spades, Rank.Ace);
            Card thirdAce = new Card(Suit.Diamonds, Rank.Ace);
            Card fourthAce = new Card(Suit.Clubs, Rank.Ace);

            Hand hand = new Hand();

            // act
            hand.AddCard(firstAce);
            hand.AddCard(secondAce);
            hand.AddCard(thirdAce);
            hand.AddCard(fourthAce);

            // assert
            Assert.AreEqual(14, hand.TotalValue);
        }

        [TestMethod]
        public void CalculateTotalValue_TwoJacksAndOneAceIs21()
        {
            // assign
            Card firstCard = new Card(Suit.Hearts, Rank.Jack);
            Card secondCard = new Card(Suit.Spades, Rank.Jack);
            Card thirdCard = new Card(Suit.Diamonds, Rank.Ace);

            Hand hand = new Hand();

            // act
            hand.AddCard(firstCard);
            hand.AddCard(secondCard);
            hand.AddCard(thirdCard);

            // assert
            Assert.AreEqual(21, hand.TotalValue);
        }

        [TestMethod]
        public void CalculateTotalValue_PlayableIsFalse_ValueLargerThan21()
        {
            // assign
            Card firstCard = new Card(Suit.Hearts, Rank.Jack);
            Card secondCard = new Card(Suit.Spades, Rank.Jack);
            Card thirdCard = new Card(Suit.Diamonds, Rank.Two);

            Hand hand = new Hand();

            // act
            hand.AddCard(firstCard);
            hand.AddCard(secondCard);
            hand.AddCard(thirdCard);

            // assert
            Assert.IsFalse(hand.Playable);
        }

        [TestMethod]
        public void CalculateTotalValue_FourAcesHandIsStillPlayable()
        {
            // assign
            Card firstAce = new Card(Suit.Hearts, Rank.Ace);
            Card secondAce = new Card(Suit.Spades, Rank.Ace);
            Card thirdAce = new Card(Suit.Diamonds, Rank.Ace);
            Card fourthAce = new Card(Suit.Clubs, Rank.Ace);

            Hand hand = new Hand();

            // act
            hand.AddCard(firstAce);
            hand.AddCard(secondAce);
            hand.AddCard(thirdAce);
            hand.AddCard(fourthAce);

            // assert
            Assert.IsTrue(hand.Playable);
        }

        [TestMethod]
        public void CalculateTotalValue_TwoJacksAndOneAceHandIsStillPlayable()
        {
            // assign
            Card firstCard = new Card(Suit.Hearts, Rank.Jack);
            Card secondCard = new Card(Suit.Spades, Rank.Jack);
            Card thirdCard = new Card(Suit.Diamonds, Rank.Ace);

            Hand hand = new Hand();

            // act
            hand.AddCard(firstCard);
            hand.AddCard(secondCard);
            hand.AddCard(thirdCard);

            // assert
            Assert.IsTrue(hand.Playable);
        }

        [TestMethod]
        public void PlaceBet_3_MakesHandBet3()
        {
            // assign
            Hand hand = new Hand();

            // act
            hand.PlaceBet(3);

            // assert
            Assert.AreEqual(3, hand.Bet);
        }

        [TestMethod]
        public void PayBet_IfBetIs5_Returns5()
        {
            // assign
            Hand hand = new Hand();
            hand.PlaceBet(5);

            // act
            int returnValue = hand.PayBet();

            // assert
            Assert.AreEqual(5, returnValue);
        }

        [TestMethod]
        public void PayBet_IfBetIsPaid_HandBetIs0()
        {
            // assign
            Hand hand = new Hand();
            hand.PlaceBet(5);

            // act
            hand.PayBet();

            // assert
            Assert.AreEqual(0, hand.Bet);
        }

        [TestMethod]
        public void CollectPayment_IfBetIs5AndPaymentIs10_NewBetIs15()
        {
            // assign
            Hand hand = new Hand();
            hand.PlaceBet(5);

            // act
            hand.CollectPayment(10);

            // assert
            Assert.AreEqual(15, hand.Bet);
        }
    }
}
