using System.ComponentModel;

namespace Rb.Common.Enums
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
}