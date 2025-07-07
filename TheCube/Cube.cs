using System.Text;

namespace TheCube
{
    /// <summary>
    /// The cube class hold all information about the cube. It's main function is to store the
    /// current state and solved state of the cube. This is also where the user menus are stored
    /// and user input is also processed in this class.
    /// </summary>
    class Cube
    {
        /* A new instance of the init object */
        private static readonly InitPieces init = new();

        /* A new instance of the turn object */
        private static readonly Turn turn = new();

        /* Instance of random class */
        private static readonly Random rand = new();

        /* The solved state of the cube to be referenced later */
        private Piece[] solvedState = new Piece[8];

        /* The state of the cube that is manipulated according to the user */
        public Piece[] cubeState = new Piece[8];

        /* The number of pieces on the cube */
        public static int NUM_PIECES = 8;

        /// <summary>
        /// Constructor for the Cube class
        /// Creates a solvedState array to store a solved reference of determining a successful
        /// solve. Then sets a copy of that to cubeState to be manipulated.
        /// </summary>
        public Cube()
        {
            solvedState = init.getPieces();
            solvedState = OrderCubeState(solvedState);
            solveCube();
        }


        /// <summary>
        /// Displays the menu and gets the choice from the user
        /// </summary>
        public void MainMenu()
        {
            bool loopVar = true;
            // string for the main menu
            StringBuilder str = new StringBuilder();
            str.AppendLine("-----Menu-----");
            str.Append("1: Move Options");
            str.Append(" | 2: Scramble");
            str.Append(" | 3: Reset");
            str.Append(" | 0: Quit");

            while (loopVar)
            {
                // display menu
                displayToUser(str);
                // get input from user
                String? choice = askForInput();
                if (choice != null)
                {
                    // passes choice to helper
                    loopVar = mainMenuSelection(choice);
                }
                else
                {
                    // if no input, pass with no params
                    mainMenuSelection();
                }
            }
        }

        /// <summary>
        /// Helper for MainMenu, process the users input and calls the correct function
        /// </summary>
        /// <param name="input">
        /// The choice of the user. Defaults to -1
        /// </param>
        /// <returns>
        /// True if input is not 0, false if it is 0
        /// </returns>
        private bool mainMenuSelection(String input = "-1")
        {
            bool toReturn = true;
            if (int.TryParse(input, out int n))
            {
                switch (input)
                {
                    // display the moves menu
                    case "1":
                        MovesMenu();
                        break;
                    // randomly scramble the cube
                    case "2":
                        displayToUser(scramble());
                        break;
                    // resets the cube to a solved state
                    case "3":
                        solveCube();
                        break;
                    // quit the application
                    case "0":
                        toReturn = false;
                        break;
                    // display the main main menu and ask for input again
                    default:
                        displayToUser("invalid input");
                        break;
                }
            }
            else
            {
                displayToUser("invalid input");
            }

            return toReturn;
        }

        private void solveCube()
        {
            cubeState = solvedState.Select(p => new Piece(p.F1.Color, p.F2.Color, p.F3.Color,
                                                          p.Position, p.Facing)).ToArray();
        }

        /// <summary>
        /// Displays the menu for the possible moves that can be made on the cube
        /// </summary>
        /// <returns>
        /// An int value representing the choice of the user
        /// </returns>
        private void MovesMenu()
        {
            bool loopVar = true;
            StringBuilder str = new StringBuilder();
            str.AppendLine("-----Moves-----");
            str.Append("1: R");
            str.Append(" | 2: R'");
            str.Append(" | 3: L");
            str.Append(" | 4: L'");
            str.Append(" | 5: U");
            str.Append(" | 6: U'");
            str.Append(" | 7: D");
            str.Append(" | 8: D'");
            str.Append(" | 9: B");
            str.Append(" | 10: B'");
            str.Append(" | 11: F");
            str.Append(" | 12: F'");
            str.Append(" | 13: Spin");
            str.Append(" | 14: Spin'");
            str.Append(" | 15: Roll");
            str.Append(" | 16: Roll'");
            str.Append(" | 0: Go Back");

            while (loopVar)
            {
                // sort the pieces by position
                cubeState = OrderCubeState(cubeState);
                printCubeState();
                // display the moves menu
                displayToUser(str);
                // Determines if the cube is in a solved state
                if (checkForWin())
                {
                    displayToUser("!!! THE CUBE IS SOLVED !!!");
                }
                // Get choice from user
                String? choice = askForInput();
                if (choice != null)
                {
                    loopVar = movesMenuSelection(choice);
                }
                else
                {
                    movesMenuSelection();
                }

            }

        }

        /// <summary>
        /// Takes in a numerical string input and calls the corresponding move in turn. Then
        /// updates the current state of the cube.
        /// </summary>
        /// <param name="input">
        /// A string representation of the input the user would like to make
        /// </param>
        /// <returns>
        /// True if the action was completed, false otherwise.
        /// </returns>
        private bool movesMenuSelection(string input = "-1")
        {
            bool toReturn = true;
            // turns string into int
            if (int.TryParse(input, out int n))
            {
                // calls turn function based on input
                switch (input)
                {
                    case "1":
                        cubeState = turn.UpdatePieces(Moves.R, false, cubeState);
                        break;
                    case "2":
                        cubeState = turn.UpdatePieces(Moves.R, true, cubeState);
                        break;
                    case "3":
                        cubeState = turn.UpdatePieces(Moves.L, false, cubeState);
                        break;
                    case "4":
                        cubeState = turn.UpdatePieces(Moves.L, true, cubeState);
                        break;
                    case "5":
                        cubeState = turn.UpdatePieces(Moves.U, false, cubeState);
                        break;
                    case "6":
                        cubeState = turn.UpdatePieces(Moves.U, true, cubeState);
                        break;
                    case "7":
                        cubeState = turn.UpdatePieces(Moves.D, false, cubeState);
                        break;
                    case "8":
                        cubeState = turn.UpdatePieces(Moves.D, true, cubeState);
                        break;
                    case "9":
                        cubeState = turn.UpdatePieces(Moves.B, false, cubeState);
                        break;
                    case "10":
                        cubeState = turn.UpdatePieces(Moves.B, true, cubeState);
                        break;
                    case "11":
                        cubeState = turn.UpdatePieces(Moves.F, false, cubeState);
                        break;
                    case "12":
                        cubeState = turn.UpdatePieces(Moves.F, true, cubeState);
                        break;
                    case "13":
                        cubeState = turn.UpdatePieces(Moves.Spin, false, cubeState);
                        break;
                    case "14":
                        cubeState = turn.UpdatePieces(Moves.Spin, true, cubeState);
                        break;
                    case "15":
                        cubeState = turn.UpdatePieces(Moves.Roll, false, cubeState);
                        break;
                    case "16":
                        cubeState = turn.UpdatePieces(Moves.Roll, true, cubeState);
                        break;
                    // quit the application
                    case "0":
                        toReturn = false;
                        break;
                    // display the main main menu and ask for input again
                    default:
                        displayToUser("invalid input");
                        break;
                }

            }
            // if the number can not be parsed or the function was called with no param
            else
            {
                displayToUser("invalid input");
            }



            return toReturn;
        }

        /// <summary>
        /// Orders the cubes state array in order of the position values of the pieces
        /// </summary>
        private Piece[] OrderCubeState(Piece[] state)
        {
            state = state.OrderBy(item => item.Position).ToArray();
            return state;
        }

        /// <summary>
        /// Prints each cubit of the cube to the console
        /// </summary>
        private void printCubeState()
        {
            // get the 3 faces to display
            char[] top = printCubeSide(Moves.U);
            char[] left = printCubeSide(Moves.L);
            char[] front = printCubeSide(Moves.F);
            // displays the ascii representation
            displayToUser($@"
             _⎽⎽⎼⎼⎻⎻⎺⎺‾ {top[1]}‾⎺⎺⎻⎻⎼⎼⎽⎽_
            |  {top[0]}  ‾⎺_⎽⎼⎼⎻⎻⎺‾⎽_  {top[3]}  |
            |‾⎺⎺⎻⎻⎼⎼⎽⎽_ {top[2]} _⎽⎼⎼⎻⎻⎺⎺‾|
            |  {left[0]}  |  {left[1]}  |  {front[0]}  |  {front[1]} |
            |‾⎺⎺⎻⎻⎼⎼⎽⎽_ | _⎽⎽⎼⎼⎻⎻⎺⎺|
            |  {left[2]}  |  {left[3]}  |  {front[2]}  | {front[3]}  |
             ‾⎺⎺⎻⎻⎼⎼⎽⎽_ | _⎽⎽⎼⎼⎻⎻⎺⎺");
        }

        /// <summary>
        /// Prints a specific side of the cube in a visual way.
        /// </summary>
        /// <param name="side">
        /// The side to display as represented by cube notation, x and z do nothing.
        /// </param>
        private char[] printCubeSide(Moves side)
        {
            StringBuilder str = new StringBuilder();
            Colors[] colorsToDisplay = new Colors[4];
            int[] piecesToMove;
            switch (side)
            {
                case Moves.B:
                    piecesToMove = [4, 5, 0, 1];
                    colorsToDisplay[0] = orientPiece(cubeState[piecesToMove[0]], side);
                    colorsToDisplay[1] = orientPiece(cubeState[piecesToMove[1]], side);
                    colorsToDisplay[2] = orientPiece(cubeState[piecesToMove[2]], side);
                    colorsToDisplay[3] = orientPiece(cubeState[piecesToMove[3]], side);
                    break;
                case Moves.D:
                    piecesToMove = [6, 7, 4, 5];
                    colorsToDisplay[0] = orientPiece(cubeState[piecesToMove[0]], side);
                    colorsToDisplay[1] = orientPiece(cubeState[piecesToMove[1]], side);
                    colorsToDisplay[2] = orientPiece(cubeState[piecesToMove[2]], side);
                    colorsToDisplay[3] = orientPiece(cubeState[piecesToMove[3]], side);
                    break;
                case Moves.F:
                    piecesToMove = [2, 3, 6, 7];
                    colorsToDisplay[0] = orientPiece(cubeState[piecesToMove[0]], side);
                    colorsToDisplay[1] = orientPiece(cubeState[piecesToMove[1]], side);
                    colorsToDisplay[2] = orientPiece(cubeState[piecesToMove[2]], side);
                    colorsToDisplay[3] = orientPiece(cubeState[piecesToMove[3]], side);
                    break;
                case Moves.U:
                    piecesToMove = [0, 1, 2, 3];
                    colorsToDisplay[0] = orientPiece(cubeState[piecesToMove[0]], side);
                    colorsToDisplay[1] = orientPiece(cubeState[piecesToMove[1]], side);
                    colorsToDisplay[2] = orientPiece(cubeState[piecesToMove[2]], side);
                    colorsToDisplay[3] = orientPiece(cubeState[piecesToMove[3]], side);
                    break;
                case Moves.R:
                    piecesToMove = [3, 1, 7, 5];
                    colorsToDisplay[0] = orientPiece(cubeState[piecesToMove[0]], side);
                    colorsToDisplay[1] = orientPiece(cubeState[piecesToMove[1]], side);
                    colorsToDisplay[2] = orientPiece(cubeState[piecesToMove[2]], side);
                    colorsToDisplay[3] = orientPiece(cubeState[piecesToMove[3]], side);
                    break;
                case Moves.L:
                    piecesToMove = [0, 2, 4, 6];
                    colorsToDisplay[0] = orientPiece(cubeState[piecesToMove[0]], side);
                    colorsToDisplay[1] = orientPiece(cubeState[piecesToMove[1]], side);
                    colorsToDisplay[2] = orientPiece(cubeState[piecesToMove[2]], side);
                    colorsToDisplay[3] = orientPiece(cubeState[piecesToMove[3]], side);
                    break;
            }

            str.Append("|");
            str.Append((char)colorsToDisplay[0]);
            str.Append("|");
            str.Append((char)colorsToDisplay[1]);
            str.AppendLine("|");

            str.Append("|");
            str.Append((char)colorsToDisplay[2]);
            str.Append("|");
            str.Append((char)colorsToDisplay[3]);
            str.AppendLine("|");

            return [(char)colorsToDisplay[0], (char)colorsToDisplay[1],
                    (char)colorsToDisplay[2], (char)colorsToDisplay[3]];
        }

        /// <summary>
        /// Helper function to printCubeSide, based on the piece and the side chosen to display
        /// this function determines the orientation of that piece and returns that color of the 
        /// face of that piece that is facing the selected side
        /// </summary>
        /// <param name="p">
        /// The piece to be oriented
        /// </param>
        /// <param name="side">
        /// The selected side to display
        /// </param>
        /// <returns>
        /// The color of the piece that is facing that side
        /// </returns>
        private Colors orientPiece(Piece p, Moves side)
        {
            int position = p.Position;
            Colors[] colorsToCheck = new Colors[3];
            switch (position)
            {
                case 1:
                    colorsToCheck = [Colors.Red, Colors.Green, Colors.White];
                    switch (side)
                    {
                        case Moves.L:
                            colorsToCheck = shiftLeft(colorsToCheck, 1);
                            break;
                        case Moves.B:
                            colorsToCheck = shiftLeft(colorsToCheck, 2);
                            break;
                    }
                    break;
                case 2:
                    colorsToCheck = [Colors.Green, Colors.Orange, Colors.White];
                    switch (side)
                    {
                        case Moves.B:
                            colorsToCheck = shiftLeft(colorsToCheck, 1);
                            break;
                        case Moves.R:
                            colorsToCheck = shiftLeft(colorsToCheck, 2);
                            break;
                    }
                    break;
                case 3:
                    colorsToCheck = [Colors.Blue, Colors.Red, Colors.White];
                    switch (side)
                    {
                        case Moves.F:
                            colorsToCheck = shiftLeft(colorsToCheck, 1);
                            break;
                        case Moves.L:
                            colorsToCheck = shiftLeft(colorsToCheck, 2);
                            break;
                    }
                    break;
                case 4:
                    colorsToCheck = [Colors.Orange, Colors.Blue, Colors.White];
                    switch (side)
                    {
                        case Moves.R:
                            colorsToCheck = shiftLeft(colorsToCheck, 1);
                            break;
                        case Moves.F:
                            colorsToCheck = shiftLeft(colorsToCheck, 2);
                            break;
                    }
                    break;
                case 5:
                    colorsToCheck = [Colors.Green, Colors.Red, Colors.Yellow];
                    switch (side)
                    {
                        case Moves.B:
                            colorsToCheck = shiftLeft(colorsToCheck, 1);
                            break;
                        case Moves.L:
                            colorsToCheck = shiftLeft(colorsToCheck, 2);
                            break;
                    }
                    break;
                case 6:
                    colorsToCheck = [Colors.Orange, Colors.Green, Colors.Yellow];
                    switch (side)
                    {
                        case Moves.R:
                            colorsToCheck = shiftLeft(colorsToCheck, 1);
                            break;
                        case Moves.B:
                            colorsToCheck = shiftLeft(colorsToCheck, 2);
                            break;
                    }
                    break;
                case 7:
                    colorsToCheck = [Colors.Red, Colors.Blue, Colors.Yellow];
                    switch (side)
                    {
                        case Moves.L:
                            colorsToCheck = shiftLeft(colorsToCheck, 1);
                            break;
                        case Moves.F:
                            colorsToCheck = shiftLeft(colorsToCheck, 2);
                            break;
                    }
                    break;
                case 8:
                    colorsToCheck = [Colors.Blue, Colors.Orange, Colors.Yellow];
                    switch (side)
                    {
                        case Moves.F:
                            colorsToCheck = shiftLeft(colorsToCheck, 1);
                            break;
                        case Moves.R:
                            colorsToCheck = shiftLeft(colorsToCheck, 2);
                            break;
                    }
                    break;
            }


            if (p.Facing == colorsToCheck[0])
            {
                return p.F2.Color;
            }
            else if (p.Facing == colorsToCheck[1])
            {
                return p.F1.Color;
            }
            else
            {
                return p.F3.Color;
            }

        }

        /// <summary>
        /// Shifts a given colors array to the left by a given amount
        /// </summary>
        /// <param name="array">
        /// The array to be shifted
        /// </param>
        /// <param name="shift">
        /// The number of times to shift it to the left
        /// </param>
        /// <returns>
        /// The new modified array
        /// </returns>
        private Colors[] shiftLeft(Colors[] array, int shift)
        {
            int len = array.Length;
            if (len == 0) return array;

            // Normalize shift amount
            shift = shift % len;
            if (shift == 0) return array;

            Colors[] result = new Colors[len];

            for (int i = 0; i < len; i++)
            {
                int newIndex = (i - shift + len) % len;
                result[newIndex] = array[i];
            }

            return result;
        }


        /// <summary>
        /// Asks the user for input to the program.
        /// </summary>
        /// <returns>
        /// A string value representing the users choice
        /// </returns>
        private String? askForInput()
        {
            Console.WriteLine();
            Console.Write("Input: ");
            return Console.ReadLine();
        }

        private void displayToUser<T>(T output)
        {
            Console.WriteLine();
            Console.WriteLine(output);
        }

        /// <summary>
        /// Because a 2x2 does not have any center pieces, the cube can be solved in any 
        /// orientation. Basically the cube can start with the white side facing up then be 
        /// manipulated so another solved state without rotation the cube itself.
        /// 
        /// Therefor the cube must be rotated and checked in every orientation before a solve can 
        /// be determined or not.
        /// 
        /// This algorithm is slightly suboptimal as it double checks 8 of the possible 24 
        /// orientations.
        /// </summary>
        /// <returns></returns>
        private bool checkForWin()
        {
            Piece[] tempCubeState = new Piece[8];
            tempCubeState = cubeState.Select(p => new Piece(p.F1.Color, p.F2.Color, p.F3.Color,
                                                            p.Position, p.Facing)).ToArray();
            //Roll loop
            for (int q = 0; q < 4; q++)
            {
                //Spin loop
                for (int j = 0; j < 4; j++)
                {
                    //Checks each piece against its counter part in the known solved state
                    if (comparePieces(tempCubeState))
                    {
                        return true;
                    }
                    //if not spin the cube and try again
                    tempCubeState = turn.UpdatePieces(Moves.Spin, false, tempCubeState);
                    tempCubeState = OrderCubeState(tempCubeState);
                }
                //if the cube is spun 4 times and still no solve has been found roll the cube 
                // and restart the possess.
                tempCubeState = turn.UpdatePieces(Moves.Roll, false, tempCubeState);
                tempCubeState = OrderCubeState(tempCubeState);
            }

            //check the two other sides
            tempCubeState = turn.UpdatePieces(Moves.Spin, false, tempCubeState);
            tempCubeState = OrderCubeState(tempCubeState);

            tempCubeState = turn.UpdatePieces(Moves.Roll, false, tempCubeState);
            tempCubeState = OrderCubeState(tempCubeState);

            //Roll loop
            for (int q = 0; q < 4; q++)
            {
                //Spin loop
                for (int j = 0; j < 4; j++)
                {
                    //Checks each piece against its counter part in the known solved state
                    if (comparePieces(tempCubeState))
                    {
                        return true;
                    }
                    //if not spin the cube and try again
                    tempCubeState = turn.UpdatePieces(Moves.Spin, false, tempCubeState);
                    tempCubeState = OrderCubeState(tempCubeState);
                }
                //if the cube is spun 4 times and still no solve has been found roll the cube and 
                // restart the possess.
                tempCubeState = turn.UpdatePieces(Moves.Roll, false, tempCubeState);
                tempCubeState = OrderCubeState(tempCubeState);
            }
            return false;
        }

        /// <summary>
        /// Checks all the pieces on the cube against the know solved state.
        /// </summary>
        /// <param name="state">
        /// The state to be checked against the solved state. Often the current state of the cube.
        /// </param>
        /// <returns>
        /// True if the cube is in a solved state
        /// </returns>
        private bool comparePieces(Piece[] state)
        {
            bool toReturn = false;
            int count = 0;
            for (int i = 0; i < solvedState.Length; i++)
            {
                if (state[i].Equals(solvedState[i]))
                {
                    count++;
                }
            }
            //If the cube is in a solved state, return true
            if (count == NUM_PIECES)
            {
                toReturn = true;
            }

            return toReturn;
        }

        /// <summary>
        /// Performs a scramble of the cube by performing 4 to 11 random turns of the cube.
        /// </summary>
        private StringBuilder scramble()
        {
            string move;
            StringBuilder scram = new StringBuilder();
            int numMoves = rand.Next(4, 12);
            for (int i = 0; i < numMoves; i++)
            {
                move = rand.Next(1, 13).ToString();
                scram.Append(move + " ");
                movesMenuSelection(move);
                cubeState = OrderCubeState(cubeState);
            }
            return scram;
        }
    }
}