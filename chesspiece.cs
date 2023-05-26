namespace Chess {
    public class ChessPiece {
        private string name;
        private int x;
        private int y;

        public void moveType() {}

        public ChessPiece(string name) {
            this.name = name;
        }
        public string Name {
            get {return this.name;}
        }
    }
}