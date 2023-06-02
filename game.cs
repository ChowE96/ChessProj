namespace Chess {
    public class Game {
        //This is the main game loop!
        public static void run() {
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

                    board.movePiece();

                    board.deselectAll();

                }
                
            }
        }
    }
}