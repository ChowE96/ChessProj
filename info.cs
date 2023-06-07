namespace Chess {
    public enum PieceName {
        Pawn,
        Bishop,
        Knight,
        Rook,
        Queen,
        King
    }

    public enum PieceColor {
        White,
        Black
    }

    public class PieceLogic {        
        // Converts icon from text to unicode glyph
        public static string convertIcon(PieceColor color, PieceName name) {
            if (color == PieceColor.White) {
                switch(name) {
                    case PieceName.Pawn:
                        return "♙";
                    case PieceName.Bishop:
                        return "♗";
                    case PieceName.Knight:
                        return "♘";
                    case PieceName.Rook:
                        return "♖";
                    case PieceName.Queen:
                        return "♕";
                    case PieceName.King:
                        return "♔";
                }
            }
            else if (color == PieceColor.Black) {
                switch(name) {
                    case PieceName.Pawn:
                        return "\u265F";
                    case PieceName.Bishop:
                        return "♝";
                    case PieceName.Knight:
                        return "♞";
                    case PieceName.Rook:
                        return "♜";
                    case PieceName.Queen:
                        return "♛";
                    case PieceName.King:
                        return "♚";
                }
            }
            return "";
        }

    //     public static List<Coord> convertMove(PieceColor color, PieceName name, int x, int y) 
    //     {
    //         List<Coord> coordArr = new List<Coord>();
            
    //         switch(name) 
    //         {
    //             case PieceName.Pawn:
    //                 if (color == PieceColor.White) 
    //                 {
    //                     coordArr.Add(new Coord(x - 2, y));
    //                     coordArr.Add(new Coord(x - 1, y));
    //                     coordArr.Add(new Coord(x - 1, y - 1));
    //                     coordArr.Add(new Coord(x - 1, y + 1));
    //                     return coordArr;
    //                 }
    //                 else if (color == PieceColor.Black)
    //                 {
    //                     coordArr.Add(new Coord(x + 2, y));
    //                     coordArr.Add(new Coord(x + 1, y));
    //                     coordArr.Add(new Coord(x + 1, y - 1));
    //                     coordArr.Add(new Coord(x + 1, y + 1));
    //                     return coordArr;
    //                 }
    //                 break;
    //             // case PieceName.Bishop:

    //             case PieceName.Knight:
    //                 coordArr.Add(new Coord(x - 2, y - 1));
    //             // case PieceName.Rook:

    //             // case PieceName.Queen:

    //             // case PieceName.King:
    //         }

    //         return coordArr;
    //     }
    }

    // public class Coord {
    //     int x;
    //     int y;

    //     public Coord(int x, int y)
    //     {
    //         this.x = x;
    //         this.y = y;
    //     }
    //     public Coord() {}
    // }
}