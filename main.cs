// See https://aka.ms/new-console-template for more information
namespace Chess {
    class Run {
        public static void Main(string[] args) {
            Board board = new Board();
            board.fillBoard();
            board.drawBoard();
            board.movePiece(Console.ReadLine());
            Console.WriteLine("This is my second commit!!");
        }
    }
}