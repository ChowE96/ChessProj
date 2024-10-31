namespace Chess {
    public class ChessPiece {
        private string name;
        // private Coord[] movement;

        public ChessPiece(PieceColor color, PieceName name) {
            this.Color = color.ToString();
            this.Name = name.ToString();
            this.Icon = PieceLogic.convertIcon(color,name);
        }

        //Properties
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        // public Coord[] Movement {
        //     get => movement;
        //     set => movement = value;
        // }
    }
}