using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rb.Common.Enums;

namespace Rb.Data.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            GoogleSearchResults = new Collection<GoogleSearchResult>();
            HathitrustResults = new Collection<HathitrustResult>();
            WorldcatResults = new Collection<WorldcatResult>();
            YandexSearchResults = new Collection<YandexSearchResult>();
        }

        public string Annotation { get; set; }

        public string Author { get; set; }

        public string Bbk { get; set; }

        public virtual ICollection<GoogleSearchResult> GoogleSearchResults { get; set; }

        public virtual ICollection<HathitrustResult> HathitrustResults { get; set; }

        [Key]
        [Column(Order = 2)]
        public int InternalId { get; set; }

        public string Isbn { get; set; }

        public string Issn { get; set; }

        public LanguageCode LanguageCode { get; set; }

        public bool ProcessedByGoogle { get; set; }

        public bool ProcessedByYandex { get; set; }

        public string PublishPlace { get; set; }

        public int PublishYear { get; set; }

        public string Publisher { get; set; }

        public string Size { get; set; }

        public string Title { get; set; }

        public string Udk { get; set; }

        public virtual ICollection<WorldcatResult> WorldcatResults { get; set; }

        public virtual ICollection<YandexSearchResult> YandexSearchResults { get; set; }
    }
}