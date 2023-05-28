namespace Chess {
    public class BoardSlot {
        private ChessPiece piece;

        public ChessPiece Piece {
            get => piece;
            set => piece = value;
        }

        public void empty() { 
            piece = new ChessPiece(); 
        }
        public bool isEmpty() {
            return( piece.Name == "" );
        }

        public BoardSlot() {
            empty();
        }
        public BoardSlot(string icon, string name) {
            piece = new ChessPiece(icon, name);
        }
    }
}