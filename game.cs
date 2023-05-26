namespace Chess {
    public class Game {
        static bool checkmate = false;
        
        public static void run() {
            Board board = new Board();
            board.fillBoard();

            while(!checkmate) {
                board.drawBoard();
                board.movePiece(Console.ReadLine());
            }
        }
    }
}