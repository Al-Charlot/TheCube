namespace TheCube
{
    /// <summary>
    /// Class the represents each face on each cubit of the cube.
    /// Contains the color of the face.
    /// </summary>
    public class Face
    {
        /* The color of the face */
        private Colors _color;

        private Colors _facing;

        /// <summary>
        /// Read only expression-bodied member for the color of the face
        /// </summary>
        public Colors Color
        {
            get => _color;
        }

        public Colors Facing
        {
            get => _facing;
            set => _facing = value;
        }

        /// <summary>
        /// Constructor for the Face class, creates a face and assigns it a color
        /// </summary>
        /// <param name="color">
        /// The color represented on the face
        /// </param>
        public Face(Colors color, Colors facing)
        {
            _color = color;
            _facing = facing;
        }

        /// <summary>
        /// Custom toString to better display what color each face is
        /// </summary>
        /// <returns>
        /// The color of the face in a formatted manor
        /// </returns>
        public override string ToString()
        {
            return $"Face: {Color}";
        }
    }
}