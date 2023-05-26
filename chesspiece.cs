namespace Chess {
    public class ChessPiece {
        private string icon;
        private string name;
        private string type;

        public void moveType(string type) {
            
        }

        public ChessPiece(string icon, string name) {
            this.icon = icon;
            this.name = name;
            this.type = name;
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