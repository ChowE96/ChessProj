namespace Chess {
    public class BoardSlot {
        private ChessPiece piece;
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
            piece = new ChessPiece(); 
        }
        public bool isEmpty() {
            return( piece.Name == "" );
        }
        public override string ToString() {
            if (isSelected) { return ">" + piece.Icon + "<"; }
            else { return "[" + piece.Icon + "]"; }
        }

        //Constructors
        public BoardSlot() {
            empty();
        }
        public BoardSlot(string icon, string name, string color) {
            piece = new ChessPiece(icon, name, color);
        }
        public BoardSlot(string id) {
            
        }
    }
}