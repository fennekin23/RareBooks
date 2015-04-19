using OfficeOpenXml;

namespace Rb.BookClassifier.Common.Reader
{
    public interface ITestSetFactory<T>
    {
        T Create(ExcelWorksheet worksheet, int row);
    }
}