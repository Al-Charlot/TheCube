namespace TheCube
{
    /// <summary>
    /// The runner class is the entry point to TheCube program
    /// 
    /// This program serves as an emulator for a 2x2x2 Rubik's Cube.
    /// Currently TheCube operates on the command line with no GUI implemented at this time.
    /// It allows for scrambling and the execution of all legal moves.
    /// </summary>
    class Runner
    {
        /// <summary>
        /// Creates a new Cube and runs the main menu to start the program
        /// </summary>
        /// <param name="args">
        /// Command line arguments (no used)
        /// </param>
        public static void Main(string[] args)
        {
            // Create the cubits of the cube
            Cube box = new();
            box.MainMenu();
        }
    }
}