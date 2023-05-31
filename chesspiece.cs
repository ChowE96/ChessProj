namespace Chess {
    public class ChessPiece {
        private string icon;
        private string name;
        private string color;
        
        public ChessPiece() {
            this.icon = "  ";
            this.name = "";
        }
        public ChessPiece(string icon, string name, string color) {
            this.icon = icon;
            this.name = name;
            this.color = color;
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
        public string Color {
            get => color;
            set => color = value;
        }
    }
}