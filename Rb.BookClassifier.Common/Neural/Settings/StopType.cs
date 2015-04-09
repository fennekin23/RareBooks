using System;

namespace Rb.BookClassifier.Common.Neural.Settings
{
    [Flags]
    public enum StopType
    {
        Epoch = 1,
        Error = 2,
        Time = 4,
        Any = Epoch | Error | Time
    }
}