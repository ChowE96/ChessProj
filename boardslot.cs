namespace Chess {
    public class BoardSlot {
        private ChessPiece? piece;
        private bool isSelected = false;

        public ChessPiece Piece {
            get => piece;
            set => piece = value;
        }
        public bool IsSelected {
            get => isSelected;
            set => isSelected = value;
        }

        public void empty() { 
            piece = null;
        }
        public bool isEmpty() {
            return(piece == null);
        }
        public override string ToString() {
            string str;
            if (piece == null) { str = " "; } 
            else { str = piece.Icon; }
            if (isSelected) { return ">" + str + "<"; }
            else { return "[" + str + "]"; }
        }

        //Constructors
        public BoardSlot() {
            empty();
        }
        public BoardSlot(PieceColor color,PieceName name) {
            piece = new ChessPiece(color,name);
        }
    }
}