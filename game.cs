namespace Chess {
    public class Game {
        //This is the main game loop!
        public static void run() {
            // Change from ASCII to Unicode
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Board board = new Board();
            board.fillBoard();

            // Debug 
            // Empty board + manual spawn
            // board.fillEmptyBoard();
            // board.spawnPiece("BP",0,3);

            while(!board.isCheckmate()) {

                board.drawBoard();

                if (board.selectPiece()) {

                    board.drawBoard();

                    if (board.movePiece()) {

                        board.nextTurn();

                    }
    
                }

                board.deselectAll();

            }
        }
    }
}