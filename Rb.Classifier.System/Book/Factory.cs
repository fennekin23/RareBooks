using System;
using System.Linq;
using Rb.Data;

namespace Rb.System.Book
{
    internal class Factory
    {
        public static Book Read(int internalId)
        {
            using (var repository = new GenericRepository<Data.Entities.Book>())
            {
                var data = repository.Items.FirstOrDefault(i => i.InternalId == internalId);
                if (data != null)
                {
                    var book = new Book
                    {
                        Annotation = data.Annotation,
                        Author = data.Author,
                        InternalId = data.InternalId,
                        IsBbkExists = !string.IsNullOrWhiteSpace(data.Bbk),
                        Language = (int) data.LanguageCode,
                        Title = data.Title,
                        Year = data.PublishYear
                    };

                    return book;
                }

                throw new Exception("Can't find book with internal id: " + internalId);
            }
        }
    }
}