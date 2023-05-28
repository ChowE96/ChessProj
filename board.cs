using System.Collections;

namespace Chess {
    public class Board {
        private BoardSlot[,] boardXY = new BoardSlot[8, 8];
        //private List<ChessPiece> boardXY2 = new List<ChessPiece>(boardXY);

        //Instantiates all the pieces and sets up the board for a game
        public void fillBoard() {
            for(int x = 0; x < boardXY.GetLength(0); x++) {
                for(int y = 0; y < boardXY.GetLength(1); y++) {
                    
                    //Pawns
                    if (x == 1) { boardXY[x,y] = new BoardSlot("BP","Pawn"); }
                    if (x == 6) { boardXY[x,y] = new BoardSlot("WP","Pawn"); }

                    //Bishops
                    if ((x == 0 && y == 2) || (x == 0 && y == 5)) { boardXY[x,y] = new BoardSlot("BB","Bishop"); }
                    if ((x == 7 && y == 2) || (x == 7 && y == 5)) { boardXY[x,y] = new BoardSlot("WB","Bishop"); }

                    //Knights
                    if ((x == 0 && y == 1) || (x == 0 && y == 6)) { boardXY[x,y] = new BoardSlot("BN","Knight"); }
                    if ((x == 7 && y == 1) || (x == 7 && y == 6)) { boardXY[x,y] = new BoardSlot("WN","Knight"); }

                    //Rooks
                    if ((x == 0 && y == 0) || (x == 0 && y == 7)) { boardXY[x,y] = new BoardSlot("BR","Rook"); }
                    if ((x == 7 && y == 0) || (x == 7 && y == 7)) { boardXY[x,y] = new BoardSlot("WR","Rook"); }

                    //Queens
                    if ((x == 0 && y == 3)) { boardXY[x,y] = new BoardSlot("BQ","Queen"); }
                    if ((x == 7 && y == 3)) { boardXY[x,y] = new BoardSlot("WQ","Queen"); }

                    //Kings
                    if ((x == 0 && y == 4)) { boardXY[x,y] = new BoardSlot("BK","King"); }
                    if ((x == 7 && y == 4)) { boardXY[x,y] = new BoardSlot("WK","King"); }

                    //Empty Spaces
                    //TODO: Recognize if a spot is empty without a piece and fill that in automatically
                    if ((x == 2 || x == 3 || x == 4 || x == 5)) { boardXY[x,y] = new BoardSlot(); }               
                }
            }
        }
        //Draws the board with all the objects and empty spaces
        public void drawBoard() {
            for(int x = 0; x < boardXY.GetLength(0); x++) {
                //Chess board number coordinates
                Console.Write(8 - x);
                for(int y = 0; y < boardXY.GetLength(1); y++) {
                    Console.Write("[" + boardXY[x,y].Piece.Icon + "]");
                }
                Console.WriteLine();
            }
            Console.Write(" ");
            for(int i = 0; i < boardXY.GetLength(0); i++) {
                //Chess board letter coordinates
                Console.Write(" " + (char)(97 + i) + " " + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        //Move pieces
        public void movePiece() {
            Console.WriteLine("Please select a piece using the coordinates: ");
            char[] coord = Console.ReadLine().ToCharArray();
            int x = 8 - ((int)coord[1] - 48);
            int y = (int)coord[0] - 97;

            //Debug line
            //Console.WriteLine(x + " " + y);

            try {
                if (!boardXY[x,y].isEmpty()) {
                    Console.WriteLine("You have selected: " + boardXY[x,y].Piece.Name);
                    Console.WriteLine("Where do you want to move that piece: ");
                    coord = Console.ReadLine().ToCharArray();
                    int toX = 8 - ((int)coord[1] - 48);
                    int toY = (int)coord[0] - 97;
                    
                    try {
                        if(x == toX && y == toY) {
                            Console.WriteLine("You deselected: " + boardXY[x,y].Piece.Name);
                            return;
                        }
                        if (boardXY[toX,toY].isEmpty()) {
                            boardXY[toX,toY].Piece = boardXY[x,y].Piece;
                            boardXY[x,y].empty();
                        }
                        else {
                            boardXY[toX,toY].empty();
                            boardXY[toX,toY].Piece = boardXY[x,y].Piece;
                            boardXY[x,y].empty();
                        }
                    }
                    catch {
                        Console.WriteLine("You cannot move to that location");
                        return;
                    }
                }
                else {
                    Console.WriteLine("That piece does not exist");
                    return;
                }
            }
            catch {
                Console.WriteLine("That location doesn't exist");
                return;
            }
        }
        public bool inCheck() {
            return false;
        }
        public bool isCheckmate() {
            return false;
        }
    }
}