using BlackJack.Controller;

namespace BlackJack.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GamePrinter gamePrinter = new GamePrinter();
            GameController gameController = new GameController(gamePrinter);
            gameController.StartGame(20);
        }
    }
}