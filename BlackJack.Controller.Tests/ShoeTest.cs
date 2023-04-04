using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Controller.Tests
{
    [TestClass]
    public class ShoeTest
    {
        [TestMethod]
        public void constructor_CreatesListOf312Cards()
        {
            // assign
            Shoe shoe = new Shoe();

            // act
            int size = shoe.Cards.Count();

            // assert
            Assert.AreEqual(312, size);
        }

        [TestMethod]
        public void constructor_ListContains78CardsOfHearts()
        {
            // assign
            Shoe shoe = new Shoe();

            // act
            int cardsOfHearts = shoe.Cards.Where(s => s.Suit == Suit.Hearts).Count();

            //assert
            Assert.AreEqual(78, cardsOfHearts);
        }

        [TestMethod]
        public void constructor_ListContains24Aces()
        {
            // assign
            Shoe shoe = new Shoe();

            // act
            int aces = shoe.Cards.Where(s => s.Rank == Rank.Ace).Count();

            //assert
            Assert.AreEqual(24, aces);
        }

        [TestMethod]
        public void Shuffle_ShuffledListContainsTheSameCards()
        {
            // assign
            Shoe shoe = new Shoe();
            List<Card> initialCardList = new List<Card>(shoe.Cards);

            // act
            shoe.Shuffle();

            CollectionAssert.AreEquivalent(initialCardList, shoe.Cards);
        }

        [TestMethod]
        public void Shuffle_CardOrderInShuffledListIsDifferentFromInitialList()
        {
            // assign
            Shoe shoe = new Shoe();
            List<Card> initialCardList = new List<Card>(shoe.Cards);

            shoe.Shuffle();

            // assert
            CollectionAssert.AreNotEqual(initialCardList, shoe.Cards);
        }

        [TestMethod]
        public void TakeCard_TakeOneListCountIs311()
        {
            // assign
            var shoe = new Shoe();
            shoe.Shuffle();

            // act
            shoe.TakeCard();

            // assert
            Assert.AreEqual(311,shoe.Cards.Count());

        }

        [TestMethod]
        public void TakeCard_ReturnsTwoOfHeartsWhenNotShuffled()
        {
            // assign
            var shoe = new Shoe();

            // act
            Card card = shoe.TakeCard();

            // assert
            Assert.AreEqual(Suit.Spades, card.Suit);
            Assert.AreEqual(Rank.Two, card.Rank);
        }

        [TestMethod]
        public void TakeCard_ThirdCardReturnsFourOfHeartsWhenNotShuffled()
        {
            // assign
            var shoe = new Shoe();

            // act
            Card firstCard = shoe.TakeCard();
            Card secondCard = shoe.TakeCard();
            Card thirdCard = shoe.TakeCard();

            // assert
            Assert.AreEqual(Suit.Spades, thirdCard.Suit);
            Assert.AreEqual(Rank.Four, thirdCard.Rank);
        }

        [TestMethod]
        public void TakeCard_FourteenthCardReturnsTwoOfDiamondsWhenNotShuffled()
        {
            // assign
            var shoe = new Shoe();

            // act
            Card card = null!;
            for (int i = 0; i < 14; i++)
            {
                card = shoe.TakeCard();
            }

            // assert
            Assert.AreEqual(Suit.Hearts, card.Suit);
            Assert.AreEqual(Rank.Two, card.Rank);
        }


    }


}
