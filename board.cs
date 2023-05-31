using System.Collections;

namespace Chess {
    public class Board {
        private BoardSlot[,] boardXY = new BoardSlot[8, 8];
        private enum PieceType {
            Pawn,
            Bishop,
            Knight,
            Rook,
            Queen,
            King
        }
        private int[] currSelection = new int[2];
        private string turn; //Determines who's turn it is


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
                    if (x == 1) { boardXY[x,y] = new BoardSlot("BP","Pawn","Black"); }
                    if (x == 6) { boardXY[x,y] = new BoardSlot("WP","Pawn","White"); }

                    //Bishops
                    if ((x == 0 && y == 2) || (x == 0 && y == 5)) { boardXY[x,y] = new BoardSlot("BB","Bishop","Black"); }
                    if ((x == 7 && y == 2) || (x == 7 && y == 5)) { boardXY[x,y] = new BoardSlot("WB","Bishop","White"); }

                    //Knights
                    if ((x == 0 && y == 1) || (x == 0 && y == 6)) { boardXY[x,y] = new BoardSlot("BN","Knight","Black"); }
                    if ((x == 7 && y == 1) || (x == 7 && y == 6)) { boardXY[x,y] = new BoardSlot("WN","Knight","White"); }

                    //Rooks
                    if ((x == 0 && y == 0) || (x == 0 && y == 7)) { boardXY[x,y] = new BoardSlot("BR","Rook","Black"); }
                    if ((x == 7 && y == 0) || (x == 7 && y == 7)) { boardXY[x,y] = new BoardSlot("WR","Rook","White"); }

                    //Queens
                    if ((x == 0 && y == 3)) { boardXY[x,y] = new BoardSlot("BQ","Queen","Black"); }
                    if ((x == 7 && y == 3)) { boardXY[x,y] = new BoardSlot("WQ","Queen","White"); }

                    //Kings
                    if ((x == 0 && y == 4)) { boardXY[x,y] = new BoardSlot("BK","King","Black"); }
                    if ((x == 7 && y == 4)) { boardXY[x,y] = new BoardSlot("WK","King","White"); }

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
        public void spawnPiece(string icon, string name, string color, int x, int y) {
            boardXY[x,y] = new BoardSlot(icon,name,color);
        }

        //Select pieces using coordinates and give coordinates they can move to
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
                    
                    //Select all the squares it can move to
                    for(int i = 0; i <= 7; i++) {
                        for(int j = 0; j <= 7; j++) {
                            if ( validMove(x,y,i,j) ) {
                                // Console.Write("(" + (char)(j + 97) + "," + (8 - i) + ")");
                                boardXY[i,j].IsSelected = true;
                            }
                        }
                    }
                    // Console.WriteLine();
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
        
        //Deselect all slots
        public void deselectAll() {
            for(int i = 0; i <= 7; i++) {
                for(int j = 0; j <= 7; j++) {
                    currSelection = new int[2];
                    boardXY[i,j].IsSelected = false;  
                }
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
                    return;
                }
                if(validMove(x,y,toX,toY)) {
                    if (boardXY[toX,toY].isEmpty()) {
                        boardXY[toX,toY].Piece = boardXY[x,y].Piece;
                        boardXY[x,y].empty();
                        return;
                    }
                    else {
                        boardXY[toX,toY].empty();
                        boardXY[toX,toY].Piece = boardXY[x,y].Piece;
                        boardXY[x,y].empty();
                        return;
                    }
                }
                else {
                    Console.WriteLine("You cannot move to that location");
                    return;
                }
            }
            catch {
                Console.WriteLine("You cannot move to that location");
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
                    if ( (toX == x + 1) && boardXY[x,y].Piece.Color == "Black" && (toY == y)
                        || (toX == x - 1) && boardXY[x,y].Piece.Color == "White" && (toY == y)) {
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
                        if ( ((i == x - 2) || (i == x + 2)) && ((j == y + 1) || (j == y - 1)) 
                        || ((j == y - 2) || (j == y + 2)) && ((i== x + 1) || (i == x - 1)) ) {
                            return true;
                        }
                        else { return false; }
                    }                   

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