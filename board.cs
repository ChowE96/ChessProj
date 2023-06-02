using System.Collections;

namespace Chess {
    public class Board {
        private BoardSlot[,] boardXY = new BoardSlot[8, 8];
        private int[] currSelection = new int[2];
        private string turnColor = "White"; //Determines who's turn it is
        private List<ChessPiece> whiteDeath = new List<ChessPiece>();
        private List<ChessPiece> blackDeath = new List<ChessPiece>();

        //Instantiates all the pieces and sets up the board for a game
        public void fillBoard() {
            //Make an empty board
            fillEmptyBoard();
            
            //Pawns
            for(int y = 0; y < boardXY.GetLength(1); y++) {
                spawnPiece(PieceColor.White, PieceName.Pawn, 6, y);
                spawnPiece(PieceColor.Black, PieceName.Pawn, 1, y);
            }

            //Bishops
            spawnPiece(PieceColor.White, PieceName.Bishop, 7, 2);
            spawnPiece(PieceColor.White, PieceName.Bishop, 7, 5);
            spawnPiece(PieceColor.Black, PieceName.Bishop, 0, 2);
            spawnPiece(PieceColor.Black, PieceName.Bishop, 0, 5);

            //Knights
            spawnPiece(PieceColor.White, PieceName.Knight, 7, 1);
            spawnPiece(PieceColor.White, PieceName.Knight, 7, 6);
            spawnPiece(PieceColor.Black, PieceName.Knight, 0, 1);
            spawnPiece(PieceColor.Black, PieceName.Knight, 0, 6);

            //Rooks
            spawnPiece(PieceColor.White, PieceName.Rook, 7, 0);
            spawnPiece(PieceColor.White, PieceName.Rook, 7, 7);
            spawnPiece(PieceColor.Black, PieceName.Rook, 0, 0);
            spawnPiece(PieceColor.Black, PieceName.Rook, 0, 7);

            //Queens
            spawnPiece(PieceColor.White, PieceName.Queen, 7, 3);
            spawnPiece(PieceColor.Black, PieceName.Queen, 0, 3);

            //Kings
            spawnPiece(PieceColor.White, PieceName.King, 7, 4);
            spawnPiece(PieceColor.Black, PieceName.King, 0, 4);

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
            Console.Clear();
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
                Console.Write(" " + (char)(97 + i) + " ");
            }
            Console.WriteLine();
            Console.WriteLine("It is " + turnColor + "'s turn!");
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

                if (boardXY[x,y].Piece.Color.ToString() != turnColor) {
                    Console.WriteLine("You cannot select your opponent's pieces!");
                    System.Threading.Thread.Sleep(1500);
                    return false;
                }
                if (!boardXY[x,y].isEmpty()) {
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
                    System.Threading.Thread.Sleep(1500);
                    return false;
                }
            }
            catch {
                Console.WriteLine("That location doesn't exist");
                System.Threading.Thread.Sleep(1500);
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
        public bool movePiece() {
            int x = currSelection[0];
            int y = currSelection[1];
            Console.WriteLine("You have selected: " + boardXY[x,y].Piece.Name);
            Console.WriteLine("Where do you want to move that piece: ");
            char[] coord = Console.ReadLine().ToCharArray();
            int toX = 8 - ((int)coord[1] - 48);
            int toY = (int)coord[0] - 97;

            try {
                if(x == toX && y == toY) {
                    Console.WriteLine("You deselected: " + boardXY[x,y].Piece.Name);
                    System.Threading.Thread.Sleep(1500);
                    return false;
                }
                if(validMove(x,y,toX,toY)) {
                    if (boardXY[toX,toY].isEmpty()) {
                        boardXY[toX,toY].Piece = boardXY[x,y].Piece;
                        boardXY[x,y].empty();
                        return true;
                    }
                    else {
                        boardXY[toX,toY].empty();
                        boardXY[toX,toY].Piece = boardXY[x,y].Piece;
                        boardXY[x,y].empty();
                        return true;
                    }
                }
                else {
                    Console.WriteLine("You cannot move to that location");
                    System.Threading.Thread.Sleep(1500);
                    return false;
                }
            }
            catch {
                Console.WriteLine("You cannot move to that location");
                System.Threading.Thread.Sleep(1500);
                return false;
            }
        }
        
        //Passes turn
        public void nextTurn() {
            if (turnColor == "White") { turnColor = "Black"; }
            else { turnColor = "White"; }
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
            SortedList<int,int> sList;

            if ( (boardXY[toX,toY].Piece != null) && (boardXY[toX,toY].Piece.Color == turnColor) ) { return false; }

            switch (type) {
                case PieceName.Pawn:
                    if ( (toX == x + 1) && boardXY[x,y].Piece.Color == "Black" && ( (toY == y) || boardXY[toX,toY].Piece != null && ((toY == y + 1) || (toY == y - 1)) ) 
                        || (toX == x - 1) && boardXY[x,y].Piece.Color == "White" && ( (toY == y) || boardXY[toX,toY].Piece != null && ((toY == y + 1) ||  (toY == y - 1)) ) 
                        || (toX == x + 2) && boardXY[x,y].Piece.Color == "Black" && (toY == y) && (x == 1)
                        || (toX == x - 2) && boardXY[x,y].Piece.Color == "White" && (toY == y) && (x == 6) ) {
                        if ( isCollision(toX,toY) ) { return false; }
                        return true;
                    }
                    break;
                case PieceName.Bishop:
                    if ( ((toX == x + offset) && (toY == y + offset))
                        || ((toX == x + offset) && (toY == y - offset))) {
                        if ( isCollision(toX,toY) ) { return false; }
                        return true;
                    }
                    break;
                case PieceName.Knight:
                    if ( ((toX == x - 2) || (toX == x + 2)) && ((toY == y + 1) || (toY == y - 1)) 
                    || ((toY == y - 2) || (toY == y + 2)) && ((toX == x + 1) || (toX == x - 1)) ) {
                        return true;
                    }
                    // sList = new SortedList<int, int>();
                    // sList.Add(x,y);
                    break;
                case PieceName.Rook:
                    if ( (toX == x) || (toY == y) ) {
                        if ( isCollision(toX,toY) ) { return false; }
                        return true;
                    }
                    break;
                case PieceName.Queen:
                    if ( (((toX == x + offset) && (toY == y + offset))
                        || ((toX == x + offset) && (toY == y - offset)))
                        || ((toX == x) || (toY == y)) ) {
                        if ( isCollision(toX,toY) ) { return false; }
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
        public bool isCollision(int toX, int toY) {
            int x = currSelection[0];
            int y = currSelection[1];
            
            //Checks top
            if ( (toX < x) && (toY == y) ) {
                for (int i = x - 1; i > toX; i--) {
                    if (boardXY[i,y].Piece != null) {
                        return true;
                    }
                }
            }

            //Checks top right
            if ( (x - toX == toY - y) && (toX < x) ) {
                int j = y;
                for (int i = x - 1; i > toX; i--) {
                    j++;
                    if (boardXY[i,j].Piece != null) {
                        return true;
                    }
                }
            }

            //Checks right
            if ( (toY > y) && (toX == x) ) {
                for (int i = y + 1; i < toY; i++) {
                    if (boardXY[x,i].Piece != null) {
                        return true;
                    }
                }
            }

            //Checks bottom right
            if ( (toX - x == toY - y) && (toX > x) ) {
                int j = y;
                for (int i = x + 1; i < toX; i++) {
                    j++;
                    if (boardXY[i,j].Piece != null) {
                        return true;
                    }
                }
            }

            //Checks bottom
            if ( (toX > x) && (toY == y) ) {
                for (int i = x + 1; i < toX; i++) {
                    if (boardXY[i,y].Piece != null) {
                        return true;
                    }
                }
            }

            //Checks bottom left
            if ( (toX - x == y - toY) && (toX > x) ) {
                int j = y;
                for (int i = x + 1; i < toX; i++) {
                    j--;
                    if (boardXY[i,j].Piece != null) {
                        return true;
                    }
                }
            }

            //Checks left
            if ( (toY < y) && (toX == x) ) {
                for (int i = y - 1; i > toY; i--) {
                    if (boardXY[x,i].Piece != null) {
                        return true;
                    }
                }
            }

            //Checks top left
            if ( (x - toX == y - toY) && (toX < x) ) {
                int j = y;
                for (int i = x - 1; i > toX; i--) {
                    j--;
                    if (boardXY[i,j].Piece != null) {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}