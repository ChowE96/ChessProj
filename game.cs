namespace Chess {
    public class Game {
        //This is the main game loop!
        public static void run() {
            Board board = new Board();
            // board.fillBoard();
            board.fillEmptyBoard();

            // Spawning in objects
            board.spawnPiece("2",5,5);
            
            while(!board.isCheckmate()) {

                board.drawBoard();

                if (board.selectPiece()) {
                    
                    board.drawBoard();

                    board.movePiece();

                }
                
            }
        }
    }
}