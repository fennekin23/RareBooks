using System;
using System.Collections.Generic;

namespace Rb.System.Classifier
{
    internal class RequestTypeClassfier : Book<Common.Enums.RequestType>
    {
        private readonly Dictionary<int, Common.Enums.RequestType> outputToRequestTypeMap = new Dictionary
            <int, Common.Enums.RequestType>
        {
            { 0, Common.Enums.RequestType.NoLangExactTitle },
            { 1, Common.Enums.RequestType.NoLangTitleAllInTitle },
            { 2, Common.Enums.RequestType.NoLangTitleYear },
            { 3, Common.Enums.RequestType.NoLangExactTitleAuthor }
        };

        public RequestTypeClassfier()
            : base("RequestType")
        {
        }

        public override Common.Enums.RequestType GetResult(Book.Book book)
        {
            var result = Compute(book);

            var index = Array.FindIndex(result, r => r > 0);

            return index != -1 ? outputToRequestTypeMap[index] : Common.Enums.RequestType.Unknown;
        }
    }
}