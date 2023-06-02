namespace Chess {
    public class ChessPiece {
        private string icon;
        private string name;
        private string color;

        public ChessPiece(PieceColor color, PieceName name) {
            this.color = color.ToString();
            this.name = name.ToString();
            convertIcon(color,name);
        }
        
        // Converts icon from text to unicode glyph
        public void convertIcon(PieceColor color, PieceName name) {
            if (color == PieceColor.White) {
                switch(name) {
                    case PieceName.Pawn:
                        icon = "♙";
                        break;
                    case PieceName.Bishop:
                        icon = "♗";
                        break;
                    case PieceName.Knight:
                        icon = "♘";
                        break;
                    case PieceName.Rook:
                        icon = "♖";
                        break;
                    case PieceName.Queen:
                        icon = "♕";
                        break;
                    case PieceName.King:
                        icon = "♔";
                        break;
                }
            }
            else if (color == PieceColor.Black) {
                switch(name) {
                    case PieceName.Pawn:
                        icon = "\u265F";
                        break;
                    case PieceName.Bishop:
                        icon = "♝";
                        break;
                    case PieceName.Knight:
                        icon = "♞";
                        break;
                    case PieceName.Rook:
                        icon = "♜";
                        break;
                    case PieceName.Queen:
                        icon = "♛";
                        break;
                    case PieceName.King:
                        icon = "♚";
                        break;
                }
            }
        }

        //Properties
        public string Icon {
            get => icon;
            set => icon = value;
        }
        public string Name {
            get => name;
            set => name = value;
        }
        public string Color {
            get => color;
            set => color = value;
        }
    }
}