namespace Chess {
    public class Board {
        private ChessPiece[,] boardXY = new ChessPiece[8, 8];

        //Instantiates all the pieces and sets up the board for a game
        public void fillBoard() {
            for(int x = 0; x < boardXY.GetLength(0); x++) {
                for(int y = 0; y < boardXY.GetLength(1); y++) {
                    
                    //Pawns
                    if (x == 1) { boardXY[x,y] = new ChessPiece("BP"); }
                    if (x == 6) { boardXY[x,y] = new ChessPiece("WP"); }

                    //Bishops
                    if ((x == 0 && y == 2) || (x == 0 && y == 5)) { boardXY[x,y] = new ChessPiece("BB"); }
                    if ((x == 7 && y == 2) || (x == 7 && y == 5)) { boardXY[x,y] = new ChessPiece("WB"); }

                    //Knights
                    if ((x == 0 && y == 1) || (x == 0 && y == 6)) { boardXY[x,y] = new ChessPiece("BN"); }
                    if ((x == 7 && y == 1) || (x == 7 && y == 6)) { boardXY[x,y] = new ChessPiece("WN"); }

                    //Rooks
                    if ((x == 0 && y == 0) || (x == 0 && y == 7)) { boardXY[x,y] = new ChessPiece("BR"); }
                    if ((x == 7 && y == 0) || (x == 7 && y == 7)) { boardXY[x,y] = new ChessPiece("WR"); }

                    //Queens
                    if ((x == 0 && y == 3)) { boardXY[x,y] = new ChessPiece("BQ"); }
                    if ((x == 7 && y == 3)) { boardXY[x,y] = new ChessPiece("WQ"); }

                    //Kings
                    if ((x == 0 && y == 4)) { boardXY[x,y] = new ChessPiece("BK"); }
                    if ((x == 7 && y == 4)) { boardXY[x,y] = new ChessPiece("WK"); }
                }
            }
        }
        //Draws the board with all the objects and empty spaces
        public void drawBoard() {
            for(int x = 0; x < boardXY.GetLength(0); x++) {
                Console.Write(8 - x);
                for(int y = 0; y < boardXY.GetLength(1); y++) {
                    if (boardXY[x,y] != null) {
                        Console.Write("[" + boardXY[x,y].Name + "]");
                    }
                    else {
                        Console.Write("[" + "  " + "]");
                    }    
                }
                Console.WriteLine();
            }
            Console.Write(" ");
            for(int i = 0; i < boardXY.GetLength(0); i++) {
                Console.Write(" " + (char)(97 + i) + " " + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        //Move pieces
        public void movePiece(String input) {
            
        }
    }
}