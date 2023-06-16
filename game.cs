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
            // board.makeBoard();
            // board.spawnPiece(PieceColor.White, PieceName.King, 2, 6);
            // board.spawnPiece(PieceColor.Black, PieceName.King, 0, 7);
            // board.spawnPiece(PieceColor.White, PieceName.Queen, 1, 5);

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

            board.drawBoard();
            Console.WriteLine("Checkmate is on the board!");
            Console.WriteLine("Press any key to continue: ");
            Console.ReadLine();
        }
    }
}