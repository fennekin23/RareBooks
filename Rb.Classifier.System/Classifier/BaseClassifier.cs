using Rb.Classifier.System;

namespace Rb.System.Classifier
{
    internal abstract class BaseClassifier<TResult, TEntity>
    {
        protected readonly NeuralNetwork Network;

        protected BaseClassifier(string classifierName)
        {
            var networkSettingsFile = string.Format("../../../Rb.BookClassifier.{0}/bin/networkSettings.txt", classifierName);
            Network = NeuralNetwork.Create(networkSettingsFile);
        }

        public abstract TResult GetResult(TEntity item);
    }
}