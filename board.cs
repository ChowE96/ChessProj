using System.Collections;

namespace Chess {
    public class Board {
        private BoardSlot[,] boardXY = new BoardSlot[8, 8];
        private int[] currSelection = new int[2];
        private string turn; //Determines who's turn it is


        //Instantiates all the pieces and sets up the board for a game
        public void fillBoard() {
            for(int x = 0; x < boardXY.GetLength(0); x++) {
                for(int y = 0; y < boardXY.GetLength(1); y++) {
                    
                    //Pawns
                    if (x == 6) { boardXY[x,y] = new BoardSlot(PieceColor.White, PieceName.Pawn); }
                    if (x == 1) { boardXY[x,y] = new BoardSlot(PieceColor.Black, PieceName.Pawn); }

                    //Bishops
                    if ((x == 7 && y == 2) || (x == 0 && y == 5)) { boardXY[x,y] = new BoardSlot(PieceColor.White, PieceName.Bishop); }
                    if ((x == 0 && y == 2) || (x == 7 && y == 5)) { boardXY[x,y] = new BoardSlot(PieceColor.Black, PieceName.Bishop); }

                    //Knights
                    if ((x == 7 && y == 1) || (x == 0 && y == 6)) { boardXY[x,y] = new BoardSlot(PieceColor.White, PieceName.Knight); }
                    if ((x == 0 && y == 1) || (x == 7 && y == 6)) { boardXY[x,y] = new BoardSlot(PieceColor.Black, PieceName.Knight); }

                    //Rooks
                    if ((x == 7 && y == 0) || (x == 0 && y == 7)) { boardXY[x,y] = new BoardSlot(PieceColor.White, PieceName.Rook); }
                    if ((x == 0 && y == 0) || (x == 7 && y == 7)) { boardXY[x,y] = new BoardSlot(PieceColor.Black, PieceName.Rook); }

                    //Queens
                    if ((x == 7 && y == 3)) { boardXY[x,y] = new BoardSlot(PieceColor.White, PieceName.Queen); }
                    if ((x == 0 && y == 3)) { boardXY[x,y] = new BoardSlot(PieceColor.Black, PieceName.Queen); }

                    //Kings
                    if ((x == 7 && y == 4)) { boardXY[x,y] = new BoardSlot(PieceColor.White, PieceName.King); }
                    if ((x == 0 && y == 4)) { boardXY[x,y] = new BoardSlot(PieceColor.Black, PieceName.King); }

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
        public void spawnPiece(PieceColor color, PieceName name, int x, int y) {
            boardXY[x,y] = new BoardSlot(color,name);
        }

        //Select pieces using coordinates and give coordinates they can move to
        public bool selectPiece() {
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
                                boardXY[i,j].IsSelected = true;
                            }
                        }
                    }
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
        
        //Checks the boardstate for check
        public bool inCheck() {
            return false;
        }
        
        //Checks to see if the current player can get out of check
        public bool isCheckmate() {
            return false;
        }
        public bool validMove(int x, int y, int toX, int toY) {
            PieceName type = Enum.Parse<PieceName>(boardXY[x,y].Piece.Name);
            int offset = toX - x;
                switch (type) {
                case PieceName.Pawn:
                    if ( (toX == x + 1) && boardXY[x,y].Piece.Color == "Black" && ( (toY == y) || boardXY[toX,toY].Piece != null && ((toY == y + 1) || (toY == y - 1)) ) 
                        || (toX == x - 1) && boardXY[x,y].Piece.Color == "White" && ( (toY == y) || boardXY[toX,toY].Piece != null && ((toY == y + 1) ||  (toY == y - 1)) ) 
                        || (toX == x + 2) && boardXY[x,y].Piece.Color == "Black" && (toY == y) && (x == 1)
                        || (toX == x - 2) && boardXY[x,y].Piece.Color == "White" && (toY == y) && (x == 6) ) {
                        return true;
                    }
                    break;
                case PieceName.Bishop:
                    if ( ((toX == x + offset) && (toY == y + offset))
                        || ((toX == x + offset) && (toY == y - offset))) {
                        return true;
                    }
                    break;
                case PieceName.Knight:
                    if ( ((toX == x - 2) || (toX == x + 2)) && ((toY == y + 1) || (toY == y - 1)) 
                    || ((toY == y - 2) || (toY == y + 2)) && ((toX == x + 1) || (toX == x - 1)) ) {
                        return true;
                    }
                    break;
                case PieceName.Rook:
                    if ( (toX == x) || (toY == y) ) {
                        return true;
                    }
                    break;
                case PieceName.Queen:
                    if ( (((toX == x + offset) && (toY == y + offset))
                        || ((toX == x + offset) && (toY == y - offset)))
                        || ((toX == x) || (toY == y)) ) {
                        return true;
                    }
                    break;
                case PieceName.King:
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
            return false;
        }       
        public bool isCollision(int x, int y, int toX, int toY) {
            return false;
        }
    }
}