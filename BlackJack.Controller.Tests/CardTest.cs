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
    }
}