using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rb.Data.Entities
{
    public enum LanguageCode
    {
        Chu, // Церковнослов'янська
        Dut, // Голландська
        Eng, // Англійська
        Fin, // Фінська
        Fre, // Французька
        Ger, // Німецька
        Heb, // Іврит
        Ita, // Італійська
        Lat, // Латинська
        Lav, // Латвійська
        Mul, // Декілька мов
        Pol, // Польська
        Rus, // Російська
        Sla, // Слов'янська
        Ukr, // Українська
        Unknown = 0
    }

    public class Book : BaseEntity
    {
        public Book()
        {
            HathitrustResults = new Collection<HathitrustResult>();
            WorldcatResults = new Collection<WorldcatResult>();
        }

        public string Author { get; set; }
        public string Bbk { get; set; }
        public virtual ICollection<HathitrustResult> HathitrustResults { get; set; }

        [Key]
        [Column(Order = 2)]
        public int InternalId { get; set; }

        public string Isbn { get; set; }
        public string Issn { get; set; }
        public LanguageCode LanguageCode { get; set; }
        public bool ProcessedByYandex { get; set; }
        public string PublishPlace { get; set; }
        public int PublishYear { get; set; }
        public string Publisher { get; set; }
        public string Size { get; set; }
        public string Title { get; set; }
        public string Udk { get; set; }
        public virtual ICollection<WorldcatResult> WorldcatResults { get; set; }
    }
}