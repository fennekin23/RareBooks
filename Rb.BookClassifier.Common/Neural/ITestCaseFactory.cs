namespace Rb.BookClassifier.Common.Neural
{
    public interface ITestCaseFactory<TEntity>
    {
        ITestCase<TEntity> Create(TEntity entity);
    }
}