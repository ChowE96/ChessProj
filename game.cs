namespace Chess {
    public class Game {
        public static void run() {
            Board board = new Board();
            board.fillBoard();

            while(!board.inCheckmate()) {
                board.drawBoard();
                board.movePiece(Console.ReadLine());
            }
        }
    }
}