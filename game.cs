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
            // board.spawnPiece(PieceColor.White, PieceName.Queen, 5, 5);
            // board.spawnPiece(PieceColor.Black, PieceName.King, 3, 4);

            while(!board.isCheckmate()) {

                board.drawBoard();

                if ( board.inCheck() ) { Console.WriteLine("You are in check!"); }

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