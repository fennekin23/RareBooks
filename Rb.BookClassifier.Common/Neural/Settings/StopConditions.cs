using System;

namespace Rb.BookClassifier.Common.Neural.Settings
{
    public class StopConditions
    {
        private readonly StopType stopType;

        public StopConditions(
            StopType stopType = StopType.Time,
            int maxEpochCount = 5000,
            double maxMainSquareError = 1.0,
            TimeSpan? maxTimeForLearning = null)
        {
            MaxEpochCount = maxEpochCount;
            MaxMainSquareError = maxMainSquareError;
            MaxTimeForLearning = maxTimeForLearning ?? TimeSpan.FromMinutes(1);
            this.stopType = stopType;
        }

        public int MaxEpochCount { get; set; }

        public double MaxMainSquareError { get; set; }

        public TimeSpan MaxTimeForLearning { get; set; }

        public bool IsStopConditionsReached(int epoch, double error, TimeSpan time)
        {
            var result = false;

            if (stopType.HasFlag(StopType.Epoch))
            {
                var epochCountIsLessThanMax = MaxEpochCount > epoch;
                result |= !epochCountIsLessThanMax;
            }

            if (stopType.HasFlag(StopType.Error))
            {
                var errorIsLessThanMax = MaxMainSquareError > error;
                result |= errorIsLessThanMax;
            }

            if (stopType.HasFlag(StopType.Time))
            {
                var timeIsLessThanMax = MaxTimeForLearning > time;
                result |= !timeIsLessThanMax;
            }

            return result;
        }
    }
}