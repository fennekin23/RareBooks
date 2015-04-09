namespace Rb.BookClassifier.Common.Neural.Settings
{
    internal class NetworkSize
    {
        public NetworkSize(int input, int output)
        {
            Input = input;
            Output = output;
        }

        public int Input { get; private set; }

        public int Output { get; private set; }
    }
}