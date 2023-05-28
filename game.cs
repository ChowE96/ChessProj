namespace Chess {
    public class Game {
        //This is the main game loop!
        public static void run() {
            Board board = new Board();
            board.fillBoard();

            while(!board.isCheckmate()) {

                board.drawBoard();

                board.movePiece();
                
            }
        }
    }
}