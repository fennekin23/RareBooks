using System.Collections.Generic;

namespace Rb.BookClassifier.Common.Neural
{
    internal class LearningResult
    {
        public LearningResult(double actualError, int errors, Dictionary<int, double> learningProcess)
        {
            ActualError = actualError;
            Errors = errors;
            LearningProcess = learningProcess;
        }

        public double ActualError { get; set; }

        public int Errors { get; set; }

        public Dictionary<int, double> LearningProcess { get; set; }
    }
}