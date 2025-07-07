namespace TheCube
{
    /// <summary>
    /// Interface to insure that all moves are included
    /// </summary>
    public interface ITurnable
    {

        private void executeB(ref Piece[] state, bool isPrime) { }

        private void executeD(ref Piece[] state, bool isPrime) { }

        private void executeF(ref Piece[] state, bool isPrime) { }

        private void executeU(ref Piece[] state, bool isPrime) { }

        private void executeR(ref Piece[] state, bool isPrime) { }

        private void executeL(ref Piece[] state, bool isPrime) { }

        private void executeSpin(ref Piece[] state, bool isPrime) { }

        private void executeRoll(ref Piece[] state, bool isPrime) { }
    }
}