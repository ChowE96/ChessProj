namespace Chess {
    public class ChessPiece {
        private string icon;
        private string name;
        private PieceType type;
        enum PieceType {
            Pawn,
            Bishop,
            Knight,
            Rook,
            Queen,
            King
        }

        public void moveType() {
            switch (type) {
            case PieceType.Pawn:
                break;
            case PieceType.Bishop:
                break;
            case PieceType.Knight:
                break;
            case PieceType.Rook:
                break;
            case PieceType.Queen:
                break;
            case PieceType.King:
                break;
            //Default
            default:
                Console.WriteLine("No such piece exists");
                break;
            }
        }

        public ChessPiece() {
            this.icon = "";
            this.name = "";
        }
        public ChessPiece(string icon, string name) {
            this.icon = icon;
            this.name = name;
            this.type = Enum.Parse<PieceType>(name);
        }

        //These are so cool
        public string Icon {
            get => icon;
            set => icon = value;
        }
        public string Name {
            get => name;
            set => name = value;
        }
    }
}