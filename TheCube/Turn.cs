namespace TheCube
{
    /// <summary>
    /// This class handles the operations of updating the pieces in the cube when
    /// a turn is executed. Note: turn and move are used interchangeably for the most part.
    /// </summary>
    public class Turn : ITurnable
    {
        // Note: these references do not always hold true as the cube is rotated
        // the logic is still the same so it is irrelevant

        /* Short hand for the back of the cube */
        private static Colors BACK = Colors.Green;

        /* Short hand for the front of the cube */
        private static Colors FRONT = Colors.Blue;

        /* Short hand for the top of the cube */
        private static Colors TOP = Colors.White;

        /* Short hand for the bottom of the cube */
        private static Colors BOTTOM = Colors.Yellow;

        /* Short hand for the left of the cube */
        private static Colors LEFT = Colors.Red;

        /* Short hand for the right of the cube */
        private static Colors RIGHT = Colors.Orange;
        public Turn()
        {
            //nothing to set up       
        }

        /// <summary>
        /// Function that updates the positions, and orientations of all affected pieces 
        /// for each move that is possible
        /// </summary>
        /// <param name="action">
        /// A char that represents the action the move the user wants to make 
        /// (Moves enum) (follows standard cube notation: https://myrubik.com/en/notation/2x2x2)
        /// </param>
        /// <param name="isPrime">
        /// Bool value is true if the move is a prime move (L') and false
        /// if the move is not prime (L)
        /// </param>
        /// <param name="state">
        /// The current sate of the cube that you wish to modify
        /// </param>
        /// <returns>
        /// A modified version of the state array that was passed in after the move has been
        /// executed.
        /// </returns>
        public Piece[] UpdatePieces(Moves action, bool isPrime, Piece[] state)
        {
            // Determine which turn to make
            switch (action)
            {
                case Moves.B:
                    executeB(ref state, isPrime);
                    break;

                case Moves.D:
                    executeD(ref state, isPrime);
                    break;

                case Moves.F:
                    executeF(ref state, isPrime);
                    break;

                case Moves.U:
                    executeU(ref state, isPrime);
                    break;

                case Moves.R:
                    executeR(ref state, isPrime);
                    break;

                case Moves.L:
                    executeL(ref state, isPrime);
                    break;
                //This turn spins the entire cube around the Y axis
                case Moves.Spin:
                    executeSpin(ref state, isPrime);
                    break;
                // This turn rolls the entire cube about the Z axis
                case Moves.Roll:
                    executeRoll(ref state, isPrime);
                    break;
                default:
                    // if the action is invalid then the array is returned unchanged
                    break;
            }
            // return the altered array
            return state;
        }

        /// <summary>
        /// Helper function for updatePieces, Performs operations to turn the back of the cube.
        /// </summary>
        /// <param name="state">
        /// The passes reference to the state of the cube
        /// </param>
        /// <param name="isPrime">
        /// True if the tun is prime, false otherwise.
        /// </param>
        private void executeB(ref Piece[] state, bool isPrime)
        {
            // The positions of the pieces that are affected by this turn
            int[] piecesToMove = [0, 1, 4, 5];
            // Determines if the move is prime or not
            if (!isPrime)
            {
                // changes the positions of the pieces
                state[0].Position += 4;
                state[1].Position -= 1;
                state[4].Position += 1;
                state[5].Position -= 4;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    // if the reference face is facing the top
                    if (state[i].Facing == TOP)
                    {
                        // set that face to the left
                        state[i].Facing = LEFT;
                    }
                    else if (state[i].Facing == LEFT)
                    {
                        state[i].Facing = BOTTOM;
                    }
                    else if (state[i].Facing == BOTTOM)
                    {
                        state[i].Facing = RIGHT;
                    }
                    else if (state[i].Facing == RIGHT)
                    {
                        state[i].Facing = TOP;
                    }
                }
            }
            else
            {
                // changes the positions of the pieces
                state[0].Position += 1;
                state[1].Position += 4;
                state[4].Position -= 4;
                state[5].Position -= 1;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == TOP)
                    {
                        state[i].Facing = RIGHT;
                    }
                    else if (state[i].Facing == RIGHT)
                    {
                        state[i].Facing = BOTTOM;
                    }
                    else if (state[i].Facing == BOTTOM)
                    {
                        state[i].Facing = LEFT;
                    }
                    else if (state[i].Facing == LEFT)
                    {
                        state[i].Facing = TOP;
                    }
                }
            }
        }

        /// <summary>
        /// Helper function for updatePieces, Performs operations to turn the bottom layer of the 
        /// cube.
        /// </summary>
        /// <param name="state">
        /// The passes reference to the state of the cube
        /// </param>
        /// <param name="isPrime">
        /// True if the tun is prime, false otherwise.
        /// </param>
        private void executeD(ref Piece[] state, bool isPrime)
        {
            // The positions of the pieces that are affected by this turn
            int[] piecesToMove = [4, 5, 6, 7];
            if (!isPrime)
            {
                // changes the positions of the pieces
                state[4].Position += 2;
                state[5].Position -= 1;
                state[6].Position += 1;
                state[7].Position -= 2;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == FRONT)
                    {
                        state[i].Facing = RIGHT;
                    }
                    else if (state[i].Facing == RIGHT)
                    {
                        state[i].Facing = BACK;
                    }
                    else if (state[i].Facing == BACK)
                    {
                        state[i].Facing = LEFT;
                    }
                    else if (state[i].Facing == LEFT)
                    {
                        state[i].Facing = FRONT;
                    }
                }
            }
            else
            {
                // changes the positions of the pieces
                state[4].Position += 1;
                state[5].Position += 2;
                state[6].Position -= 2;
                state[7].Position -= 1;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == FRONT)
                    {
                        state[i].Facing = LEFT;
                    }
                    else if (state[i].Facing == LEFT)
                    {
                        state[i].Facing = BACK;
                    }
                    else if (state[i].Facing == BACK)
                    {
                        state[i].Facing = RIGHT;
                    }
                    else if (state[i].Facing == RIGHT)
                    {
                        state[i].Facing = FRONT;
                    }
                }
            }
        }

        /// <summary>
        /// Helper function for updatePieces, Performs operations to turn the front of the cube.
        /// </summary>
        /// <param name="state">
        /// The passes reference to the state of the cube
        /// </param>
        /// <param name="isPrime">
        /// True if the tun is prime, false otherwise.
        /// </param>
        private void executeF(ref Piece[] state, bool isPrime)
        {
            // The positions of the pieces that are affected by this turn
            int[] piecesToMove = [2, 3, 6, 7];
            if (!isPrime)
            {
                // changes the positions of the pieces
                state[2].Position += 1;
                state[3].Position += 4;
                state[6].Position -= 4;
                state[7].Position -= 1;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == TOP)
                    {
                        state[i].Facing = RIGHT;
                    }
                    else if (state[i].Facing == RIGHT)
                    {
                        state[i].Facing = BOTTOM;
                    }
                    else if (state[i].Facing == BOTTOM)
                    {
                        state[i].Facing = LEFT;
                    }
                    else if (state[i].Facing == LEFT)
                    {
                        state[i].Facing = TOP;
                    }
                }
            }
            else
            {
                // changes the positions of the pieces
                state[2].Position += 4;
                state[3].Position -= 1;
                state[6].Position += 1;
                state[7].Position -= 4;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == TOP)
                    {
                        state[i].Facing = LEFT;
                    }
                    else if (state[i].Facing == LEFT)
                    {
                        state[i].Facing = BOTTOM;
                    }
                    else if (state[i].Facing == BOTTOM)
                    {
                        state[i].Facing = RIGHT;
                    }
                    else if (state[i].Facing == RIGHT)
                    {
                        state[i].Facing = TOP;
                    }
                }
            }
        }

        /// <summary>
        /// Helper function for updatePieces, Performs operations to turn the top layer of the cube.
        /// </summary>
        /// <param name="state">
        /// The passes reference to the state of the cube
        /// </param>
        /// <param name="isPrime">
        /// True if the tun is prime, false otherwise.
        /// </param>
        private void executeU(ref Piece[] state, bool isPrime)
        {
            // The positions of the pieces that are affected by this turn
            int[] piecesToMove = [0, 1, 2, 3];
            if (!isPrime)
            {
                // changes the positions of the pieces
                state[0].Position += 1;
                state[1].Position += 2;
                state[2].Position -= 2;
                state[3].Position -= 1;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == FRONT)
                    {
                        state[i].Facing = LEFT;
                    }
                    else if (state[i].Facing == LEFT)
                    {
                        state[i].Facing = BACK;
                    }
                    else if (state[i].Facing == BACK)
                    {
                        state[i].Facing = RIGHT;
                    }
                    else if (state[i].Facing == RIGHT)
                    {
                        state[i].Facing = FRONT;
                    }
                }
            }
            else
            {
                // changes the positions of the pieces
                state[0].Position += 2;
                state[1].Position -= 1;
                state[2].Position += 1;
                state[3].Position -= 2;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == FRONT)
                    {
                        state[i].Facing = RIGHT;
                    }
                    else if (state[i].Facing == RIGHT)
                    {
                        state[i].Facing = BACK;
                    }
                    else if (state[i].Facing == BACK)
                    {
                        state[i].Facing = LEFT;
                    }
                    else if (state[i].Facing == LEFT)
                    {
                        state[i].Facing = FRONT;
                    }
                }
            }
        }

        /// <summary>
        /// Helper function for updatePieces, Performs operations to turn the right slice of the 
        /// cube.
        /// </summary>
        /// <param name="state">
        /// The passes reference to the state of the cube
        /// </param>
        /// <param name="isPrime">
        /// True if the tun is prime, false otherwise.
        /// </param>
        private void executeR(ref Piece[] state, bool isPrime)
        {
            // The positions of the pieces that are affected by this turn
            int[] piecesToMove = [1, 3, 5, 7];
            if (!isPrime)
            {
                // changes the positions of the pieces
                state[1].Position += 4;
                state[3].Position -= 2;
                state[5].Position += 2;
                state[7].Position -= 4;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == TOP)
                    {
                        state[i].Facing = BACK;
                    }
                    else if (state[i].Facing == BACK)
                    {
                        state[i].Facing = BOTTOM;
                    }
                    else if (state[i].Facing == BOTTOM)
                    {
                        state[i].Facing = FRONT;
                    }
                    else if (state[i].Facing == FRONT)
                    {
                        state[i].Facing = TOP;
                    }
                }
            }
            else
            {
                // changes the positions of the pieces
                state[1].Position += 2;
                state[3].Position += 4;
                state[5].Position -= 4;
                state[7].Position -= 2;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == TOP)
                    {
                        state[i].Facing = FRONT;
                    }
                    else if (state[i].Facing == FRONT)
                    {
                        state[i].Facing = BOTTOM;
                    }
                    else if (state[i].Facing == BOTTOM)
                    {
                        state[i].Facing = BACK;
                    }
                    else if (state[i].Facing == BACK)
                    {
                        state[i].Facing = TOP;
                    }
                }

            }
        }

        /// <summary>
        /// Helper function for updatePieces, Performs operations to turn the left slice of the 
        /// cube.
        /// </summary>
        /// <param name="state">
        /// The passes reference to the state of the cube
        /// </param>
        /// <param name="isPrime">
        /// True if the tun is prime, false otherwise.
        /// </param>
        private void executeL(ref Piece[] state, bool isPrime)
        {
            // The positions of the pieces that are affected by this turn
            int[] piecesToMove = [0, 2, 4, 6];
            if (!isPrime)
            {
                // changes the positions of the pieces
                state[0].Position += 2;
                state[2].Position += 4;
                state[4].Position -= 4;
                state[6].Position -= 2;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == TOP)
                    {
                        state[i].Facing = FRONT;
                    }
                    else if (state[i].Facing == FRONT)
                    {
                        state[i].Facing = BOTTOM;
                    }
                    else if (state[i].Facing == BOTTOM)
                    {
                        state[i].Facing = BACK;
                    }
                    else if (state[i].Facing == BACK)
                    {
                        state[i].Facing = TOP;
                    }
                }
            }
            else
            {
                // changes the positions of the pieces
                state[0].Position += 4;
                state[2].Position -= 2;
                state[4].Position += 2;
                state[6].Position -= 4;

                // correctly updates the orientation
                foreach (int i in piecesToMove)
                {
                    if (state[i].Facing == TOP)
                    {
                        state[i].Facing = BACK;
                    }
                    else if (state[i].Facing == BACK)
                    {
                        state[i].Facing = BOTTOM;
                    }
                    else if (state[i].Facing == BOTTOM)
                    {
                        state[i].Facing = FRONT;
                    }
                    else if (state[i].Facing == FRONT)
                    {
                        state[i].Facing = TOP;
                    }
                }
            }
        }

        /// <summary>
        /// Helper function for updatePieces, Performs operations to spin the cube around the y
        /// axis.
        /// </summary>
        /// <param name="state">
        /// The passes reference to the state of the cube
        /// </param>
        /// <param name="isPrime">
        /// True if the tun is prime, false otherwise.
        /// </param>
        private void executeSpin(ref Piece[] state, bool isPrime)
        {
            if (!isPrime)
            {
                // All positions are affected by this move
                state[0].Position += 1;
                state[1].Position += 2;
                state[2].Position -= 2;
                state[3].Position -= 1;
                state[4].Position += 1;
                state[5].Position += 2;
                state[6].Position -= 2;
                state[7].Position -= 1;

                // correctly updates the orientation
                foreach (Piece p in state)
                {
                    if (p.Facing == FRONT)
                    {
                        p.Facing = LEFT;
                    }
                    else if (p.Facing == LEFT)
                    {
                        p.Facing = BACK;
                    }
                    else if (p.Facing == BACK)
                    {
                        p.Facing = RIGHT;
                    }
                    else if (p.Facing == RIGHT)
                    {
                        p.Facing = FRONT;
                    }
                }
            }
            else
            {
                // All positions are affected by this move
                state[0].Position += 2;
                state[1].Position -= 1;
                state[2].Position += 1;
                state[3].Position -= 2;
                state[4].Position += 2;
                state[5].Position -= 1;
                state[6].Position += 1;
                state[7].Position -= 2;

                // correctly updates the orientation
                foreach (Piece p in state)
                {
                    if (p.Facing == FRONT)
                    {
                        p.Facing = RIGHT;
                    }
                    else if (p.Facing == RIGHT)
                    {
                        p.Facing = BACK;
                    }
                    else if (p.Facing == BACK)
                    {
                        p.Facing = LEFT;
                    }
                    else if (p.Facing == LEFT)
                    {
                        p.Facing = FRONT;
                    }
                }
            }
        }

        /// <summary>
        /// Helper function for updatePieces, Performs operations to roll the cube around the z
        /// axis.
        /// </summary>
        /// <param name="state">
        /// The passes reference to the state of the cube
        /// </param>
        /// <param name="isPrime">
        /// True if the tun is prime, false otherwise.
        /// </param>
        private void executeRoll(ref Piece[] state, bool isPrime)
        {
            if (!isPrime)
            {
                // All positions are affected by this move
                state[2].Position += 1;
                state[3].Position += 4;
                state[6].Position -= 4;
                state[7].Position -= 1;
                state[0].Position += 1;
                state[1].Position += 4;
                state[4].Position -= 4;
                state[5].Position -= 1;

                // correctly updates the orientation
                foreach (Piece p in state)
                {
                    if (p.Facing == TOP)
                    {
                        p.Facing = RIGHT;
                    }
                    else if (p.Facing == RIGHT)
                    {
                        p.Facing = BOTTOM;
                    }
                    else if (p.Facing == BOTTOM)
                    {
                        p.Facing = LEFT;
                    }
                    else if (p.Facing == LEFT)
                    {
                        p.Facing = TOP;
                    }
                }
            }
            else
            {
                // All positions are affected by this move
                state[2].Position += 4;
                state[3].Position -= 1;
                state[6].Position += 1;
                state[7].Position -= 4;
                state[0].Position += 4;
                state[1].Position -= 1;
                state[4].Position += 1;
                state[5].Position -= 4;

                // correctly updates the orientation
                foreach (Piece p in state)
                {
                    if (p.Facing == TOP)
                    {
                        p.Facing = LEFT;
                    }
                    else if (p.Facing == LEFT)
                    {
                        p.Facing = BOTTOM;
                    }
                    else if (p.Facing == BOTTOM)
                    {
                        p.Facing = RIGHT;
                    }
                    else if (p.Facing == RIGHT)
                    {
                        p.Facing = TOP;
                    }
                }
            }
        }
    }
}