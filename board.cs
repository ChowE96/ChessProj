namespace Chess {
    class Board {
        private ChessPiece[,] boardXY = new ChessPiece[8, 8];

        //This is only for debugging do not use pls
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
        public void drawBoard() {
            //LMAO this does nothing :D
            char[] letter = new char[8];
            letter[0] = 'a';
            letter[1] = 'b';
            letter[2] = 'c';
            letter[3] = 'd';
            letter[4] = 'e';
            letter[5] = 'f';
            letter[6] = 'g';
            letter[7] = 'h';
            
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
        }

        //For the developer pls don't use
        public void drawCoordinates() {
            for(int x = 0; x < boardXY.GetLength(0); x++) {
                for(int y = 0; y < boardXY.GetLength(1); y++) {
                    Console.Write(x + "," + y + " ");
                }
                Console.WriteLine();
            }
        }
        public void movePiece(String input) {
            
        }
    }
}