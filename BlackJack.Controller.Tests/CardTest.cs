using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BlackJack.Controller.Tests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void Constructor_TwoHearts_Value2()
        {
            //assign
            Card card = new Card(Suit.Hearts, Rank.Two);

            //act
            int value = card.Value;

            //assert
            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void Constructor_JackSpades_Value10()
        {
            //assign
            Card card = new Card(Suit.Spades, Rank.Jack);

            //act
            int value = card.Value;

            //assert
            Assert.AreEqual(10, value);
        }

        [TestMethod]
        public void Constructor_AceDiamonds_Value11()
        {
            //assign
            Card card = new Card(Suit.Diamonds, Rank.Ace);

            //act
            int value = card.Value;

            //assert
            Assert.AreEqual(11, value);
        }

        [TestMethod]
        public void Constructor_QueenClubs_Value10()
        {
            //assign
            Card card = new Card(Suit.Clubs, Rank.Queen);

            //act
            int value = card.Value;

            //assert
            Assert.AreEqual(10, value);
        }

        [TestMethod]
        public void Constructor_TwoHearts_SuitIsHearts()
        {
            //assign
            Card card = new Card(Suit.Hearts, Rank.Two);

            //act
            Suit suit = card.Suit;

            //assert
            Assert.AreEqual(Suit.Hearts, suit);
        }

        [TestMethod]
        public void Constructor_TwoSpades_SuitIsSpades()
        {
            //assign
            Card card = new Card(Suit.Spades, Rank.Two);

            //act
            Suit suit = card.Suit;

            //assert
            Assert.AreEqual(Suit.Spades, suit);
        }

        [TestMethod]
        public void Constructor_TwoClubs_SuitIsClubs()
        {
            //assign
            Card card = new Card(Suit.Clubs, Rank.Two);

            //act
            Suit suit = card.Suit;

            //assert
            Assert.AreEqual(Suit.Clubs, suit);
        }

        [TestMethod]
        public void Constructor_TwoDiamonds_SuitIsDiamonds()
        {
            //assign
            Card card = new Card(Suit.Diamonds, Rank.Two);

            //act
            Suit suit = card.Suit;

            //assert
            Assert.AreEqual(Suit.Diamonds, suit);
        }

        [TestMethod]
        public void Constructor_TwoHearts_RankIsTwo()
        {
            //assign
            Card card = new Card(Suit.Diamonds, Rank.Two);

            //act
            Rank rank = card.Rank;

            //assert
            Assert.AreEqual(Rank.Two, rank);
        }

        [TestMethod]
        public void Constructor_ThreeSpades_RankIsThree()
        {
            //assign
            Card card = new Card(Suit.Spades, Rank.Three);

            //act
            Rank rank = card.Rank;

            //assert
            Assert.AreEqual(Rank.Three, rank);
        }

        [TestMethod]
        public void Constructor_QueenClubs_RankIsQueen()
        {
            //assign
            Card card = new Card(Suit.Clubs, Rank.Queen);

            //act
            Rank rank = card.Rank;

            //assert
            Assert.AreEqual(Rank.Queen, rank);
        }

        [TestMethod]
        public void Constructor_AceDiamonds_RankIsAce()
        {
            //assign
            Card card = new Card(Suit.Diamonds, Rank.Ace);

            //act
            Rank rank = card.Rank;

            //assert
            Assert.AreEqual(Rank.Ace, rank);
        }

        [TestMethod]
        public void Constructor_TenDiamonds_RankIsTen()
        {
            //assign
            Card card = new Card(Suit.Diamonds, Rank.Ten);

            //act
            Rank rank = card.Rank;

            //assert
            Assert.AreEqual(Rank.Ten, rank);
        }
    }
}