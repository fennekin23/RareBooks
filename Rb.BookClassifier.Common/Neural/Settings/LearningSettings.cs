namespace Rb.BookClassifier.Common.Neural.Settings
{
    public class LearningSettings
    {
        public LearningSettings(double alpha = 0.5, double learningRate = 0.5, double momentum = 0.0)
        {
            Alpha = alpha;
            LearningRate = learningRate;
            Momentum = momentum;
        }


        public double Alpha { get; private set; }

        public double LearningRate { get; private set; }

        public double Momentum { get; private set; }
    }
}