using System.Collections;

namespace Chess {
    public class Board {
        private BoardSlot[,] boardXY = new BoardSlot[8, 8];
        enum PieceType {
            Pawn,
            Bishop,
            Knight,
            Rook,
            Queen,
            King
        }
        int[]? currSelection = new int[2];
        string turn; //Determines who's turn it is

        //Constructor
        public BoardSlot[,] BoardXY {
            get => boardXY;
            set => boardXY = value;
        }

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
        public void fillEmptyBoard() {
            for(int x = 0; x < boardXY.GetLength(0); x++) {
                for(int y = 0; y < boardXY.GetLength(1); y++) {
                    boardXY[x,y] = new BoardSlot();
                }
            }
        }

        //Draws the board with all the objects and empty spaces
        public void drawBoard() {
            for(int x = 0; x < boardXY.GetLength(0); x++) {
                //Chess board number coordinates
                Console.Write(8 - x);
                for(int y = 0; y < boardXY.GetLength(1); y++) {
                    Console.Write(boardXY[x,y]);
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
        
        //Spawns in a chess piece
        public void spawnPiece(string id, int x, int y) {
            boardXY[x,y] = new BoardSlot("WQ","Queen");
        }

        //Select pieces and give coordinates they can move to
        public bool selectPiece() {
            //Debug
            //Console.WriteLine(x + " " + y);

            try {
                Console.WriteLine("Please select a piece using the coordinates: ");
                char[] coord = Console.ReadLine().ToCharArray();
                int x = 8 - ((int)coord[1] - 48);
                int y = (int)coord[0] - 97;

                if (!boardXY[x,y].isEmpty()) {
                    Console.WriteLine("You have selected: " + boardXY[x,y].Piece.Name);
                    currSelection[0] = x;
                    currSelection[1] = y;
                    boardXY[x,y].IsSelected = true;
                    return true;
                }
                else {
                    Console.WriteLine("That piece does not exist");
                    return false;
                }
            }
            catch {
                Console.WriteLine("That location doesn't exist");
                return false;
            }
        }
        
        //Move pieces
        public void movePiece() {
            Console.WriteLine("Where do you want to move that piece: ");
            char[] coord = Console.ReadLine().ToCharArray();
            int toX = 8 - ((int)coord[1] - 48);
            int toY = (int)coord[0] - 97;
            int x = currSelection[0];
            int y = currSelection[1];

            try {
                if(x == toX && y == toY) {
                    Console.WriteLine("You deselected: " + boardXY[x,y].Piece.Name);
                    currSelection = new int[2];
                    boardXY[x,y].IsSelected = false;
                    return;
                }
                if(validMove(x,y,toX,toY)) {
                    if (boardXY[toX,toY].isEmpty()) {
                        boardXY[toX,toY].Piece = boardXY[x,y].Piece;
                        boardXY[x,y].empty();
                    }
                    else {
                        boardXY[toX,toY].empty();
                        boardXY[toX,toY].Piece = boardXY[x,y].Piece;
                        boardXY[x,y].empty();
                    }
                    currSelection = new int[2];
                    boardXY[x,y].IsSelected = false;   
                }
                else {
                    Console.WriteLine("You cannot move to that location");
                    currSelection = new int[2];
                    boardXY[x,y].IsSelected = false;
                }
            }
            catch {
                Console.WriteLine("You cannot move to that location");
                currSelection = new int[2];
                boardXY[x,y].IsSelected = false;
                return;
            }
        }
        
        //Checks the boardstate for check, probably not needed
        public bool inCheck() {
            return false;
        }
        
        //Checks to see if the game is over
        public bool isCheckmate() {
            return false;
        }
        public bool validMove(int x, int y, int toX, int toY) {
            PieceType type = Enum.Parse<PieceType>(boardXY[x,y].Piece.Name);
            int offset = toX - x;
                switch (type) {
                case PieceType.Pawn:
                    if ( (toX == x + 1)
                        || (toX == x - 1) ) {
                        return true;
                    }
                    break;
                case PieceType.Bishop:
                    if ( ((toX == x + offset) && (toY == y + offset))
                        || ((toX == x + offset) && (toY == y - offset))) {
                        return true;
                    }
                    break;
                case PieceType.Knight:
                    bool NAlg(int i, int j) {
                        // if ( (Math.Abs(x - i) == 1) && ((Math.Abs(y = j) == 2)) 
                        //     || (Math.Abs(x - i) == 2) && ((Math.Abs(y = j) == 1)) ) {
                        //     return true;
                        // }
                        if ( ((i == x - 2) || (i == x + 2)) && ((j == y + 1) || (j == y - 1)) 
                        || ((j == y - 2) || (j == y + 2)) && ((i== x + 1) || (i == x - 1)) ) {
                            return true;
                        }
                        else { return false; }
                    }                   

                    //Debug
                    // for(int i = 0; i <= 7; i++) {
                    //     for(int j = 0; j <= 7; j++) {
                    //         if ( NAlg(i,j) ) {
                    //             Console.Write("(" + (char)(j + 97) + "," + (8 - i) + ")");
                    //         }
                    //     }
                    // }
                    // Console.WriteLine();

                    if ( NAlg(toX,toY) ) {
                        return true;
                    }
                    break;
                case PieceType.Rook:
                    if ( (toX == x) || (toY == y) ) {
                        return true;
                    }
                    break;
                case PieceType.Queen:
                    if ( (((toX == x + offset) && (toY == y + offset))
                        || ((toX == x + offset) && (toY == y - offset)))
                        || ((toX == x) || (toY == y)) ) {
                        return true;
                    }
                    break;
                case PieceType.King:
                    if ( (toX == x + 1 || toX == x - 1 || toX == x) 
                        && (toY == y + 1 || toY == y - 1 || toY == y) ) {
                        return true;
                    }
                    break;
                //Default
                default:
                    Console.WriteLine("That is not a chess piece");
                    break;
                }
            //Debug
            //Console.WriteLine("Checking " + boardXY[x,y].Piece.Name + "'s movement");
            return false;
        }       
    }
}