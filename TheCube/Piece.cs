namespace TheCube
{
    /// <summary>
    /// The Piece class holds all things needed to define a piece as will as a custom toString
    /// method for better display to the console. It also includes a custom equals method
    /// that is used later on to help determine if the cube is solved or not. 
    /// 
    /// Note: Piece and Cubit are used interchangeably.
    /// </summary>
    public class Piece
    {
        /* The first face on piece */
        private Face _f1;

        /* The second face on piece */
        private Face _f2;

        /* The third face on piece */
        private Face _f3;

        /* The position of the piece  */
        private int _position;

        /* The face of the cube that the reference face (yellow or white) is facing */
        private Colors _facing;

        /// <summary>
        /// Read only expression-bodied member for the first face
        /// </summary>
        public Face F1
        {
            get => _f1;
        }

        /// <summary>
        /// Read only expression-bodied member for the second face
        /// </summary>
        public Face F2
        {
            get => _f2;
        }

        /// <summary>
        /// Read only expression-bodied member for the third face, this is also the reference face.
        /// </summary>
        public Face F3
        {
            get => _f3;
        }


        /// <summary>
        /// Read and write expression-bodied member for the position of the cubit on the cube
        /// </summary>
        public int Position
        {
            get => _position;
            set => _position = value;
        }

        /// <summary>
        /// Read and write expression-bodied member for colored side of the cube that the reference
        /// face is facing.
        /// </summary>
        public Colors Facing
        {
            get => _facing;
            set => _facing = value;
        }

        /// <summary>
        /// The constructor of the Piece class, used to create individual Piece objects
        /// </summary>
        /// <param name="col1">
        /// The color of the first face
        /// </param>
        /// <param name="col2">
        /// The color of the second face
        /// </param>
        /// <param name="col3">
        /// The color of the third face 
        /// </param>
        /// <param name="poss">
        /// The int that represents the location of piece on the cube
        /// </param>
        /// <param name="facing">
        /// The color of the side that the reference face starts facing
        /// </param>
        public Piece(Colors col1, Colors col2, Colors col3, int poss, Colors facing)
        {
            // Assign variables
            _f1 = new Face(col1, col1);
            _f2 = new Face(col2, col2);
            _f3 = new Face(col3, col3);
            _position = poss;
            _facing = facing;
        }

        /// <summary>
        /// Gives a formatted view of each piece that looks nice for the console
        /// </summary>
        /// <returns>
        /// A string representation of a Piece
        /// </returns>
        public override string ToString()
        {
            return $"This Cubit has {F1.Color},\t{F2.Color},\t{F3.Color}\t" +
                $"at position {Position}, facing {Facing}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            bool toReturn = false;
            // compares all relative parts of the Piece object
            if (obj is Piece item && F1.Color == item.F1.Color && F2.Color == item.F2.Color &&
                F3.Color == item.F3.Color && Facing == item.Facing)
            {
                toReturn = true;
            }

            return toReturn;
        }

        /// <summary>
        /// Override of GetHashCode required by compiler
        /// </summary>
        /// <returns>
        /// The hash code of the object
        /// </returns>
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}