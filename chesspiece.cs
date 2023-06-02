namespace Chess {
    public class ChessPiece {
        private string icon;
        private string name;
        private string color;

        public ChessPiece(PieceColor color, PieceName name) {
            this.color = color.ToString();
            this.name = name.ToString();
            this.icon = this.color[0].ToString();
            this.icon += this.name[0].ToString();
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