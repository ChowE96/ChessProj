namespace Chess {
    public class ChessPiece {
        private string icon;
        private string name;
        private string color;
        // private Coord[] movement;

        public ChessPiece(PieceColor color, PieceName name) {
            this.color = color.ToString();
            this.name = name.ToString();
            this.icon = PieceLogic.convertIcon(color,name);
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
        // public Coord[] Movement {
        //     get => movement;
        //     set => movement = value;
        // }
    }
}