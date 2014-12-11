using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rb.Data.Entities
{
    public enum LanguageCode
    {
        [Description("Церковнослов'янська")]
        Chu, // Церковнослов'янська
        [Description("Голландська")]
        Dut, // Голландська
        [Description("Англійська")]
        Eng, // Англійська
        [Description("Фінська")]
        Fin, // Фінська
        [Description("Французька")]
        Fre, // Французька
        [Description("Німецька")]
        Ger, // Німецька
        [Description("Іврит")]
        Heb, // Іврит
        [Description("Італійська")]
        Ita, // Італійська
        [Description("Латинська")]
        Lat, // Латинська
        [Description("Латвійська")]
        Lav, // Латвійська
        [Description("Декілька мов")]
        Mul, // Декілька мов
        [Description("Польська")]
        Pol, // Польська
        [Description("Російська")]
        Rus, // Російська
        [Description("Слов'янська")]
        Sla, // Слов'янська
        [Description("Українська")]
        Ukr, // Українська
        [Description("Невідомо")]
        Unknown = 0
    }

    public class Book : BaseEntity
    {
        public Book()
        {
            HathitrustResults = new Collection<HathitrustResult>();
            WorldcatResults = new Collection<WorldcatResult>();
        }

        public string Annotation { get; set; }
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