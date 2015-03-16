using System.Collections.Generic;
using Rb.Data;
using Rb.Data.Entities;

namespace Rb.SnippetDictionary
{
    internal abstract class SnippetReaderBase<T>
        where T : BaseEntity
    {
        protected IRepository<T> SearchResultRepository { get; set; }

        public abstract List<string> Read();

        public abstract List<string> Read(int fromYear, int toYear);
    }
}