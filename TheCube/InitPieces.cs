namespace TheCube
{
    /// <summary>
    /// The InitPieces class is a helper class of the Cube class that creates the 8 Pieces
    /// required for the 2x2x2 rubik's cube
    /// </summary>
    public class InitPieces
    {
        /* The first cubit on the cube */
        private Piece p1;

        /* The second cubit on the cube */
        private Piece p2;

        /* The third cubit on the cube */
        private Piece p3;

        /* The fourth cubit on the cube */
        private Piece p4;

        /* The fifth cubit on the cube */
        private Piece p5;

        /* The sixth cubit on the cube */
        private Piece p6;

        /* The seventh cubit on the cube */
        private Piece p7;

        /* The eighth cubit on the cube */
        private Piece p8;

        /// <summary>
        /// Creates the 8 pieces with the correct colors and positions
        /// </summary>
        public InitPieces()
        {
            // white pieces
            p1 = new Piece(Colors.Blue, Colors.Red, Colors.White, 3, Colors.White);
            p2 = new Piece(Colors.Orange, Colors.Blue, Colors.White, 4, Colors.White);
            p3 = new Piece(Colors.Green, Colors.Orange, Colors.White, 2, Colors.White);
            p4 = new Piece(Colors.Red, Colors.Green, Colors.White, 1, Colors.White);

            // yellow pieces
            p5 = new Piece(Colors.Red, Colors.Blue, Colors.Yellow, 7, Colors.Yellow);
            p6 = new Piece(Colors.Blue, Colors.Orange, Colors.Yellow, 8, Colors.Yellow);
            p7 = new Piece(Colors.Orange, Colors.Green, Colors.Yellow, 6, Colors.Yellow);
            p8 = new Piece(Colors.Green, Colors.Red, Colors.Yellow, 5, Colors.Yellow);
        }

        /// <summary>
        /// Gets the pieces created by this class
        /// </summary>
        /// <returns>
        /// An array of piece that make a full cube.
        /// </returns>
        public Piece[] getPieces()
        {
            return [p1, p2, p3, p4, p5, p6, p7, p8];
        }
    }
}