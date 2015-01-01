using System;
using System.ComponentModel;

namespace Rb.Common
{
    public static class EnumExtensions
    {
        public static string GetDescription<TEnum>(this TEnum value) where TEnum : struct
        {
            var type = typeof (TEnum);
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("{0} must be an enumerated type", type));
            }
            var name = value.ToString();
            var attributes = type.GetField(name).GetCustomAttributes(typeof (DescriptionAttribute), false);
            var result = (attributes.Length > 0) ? ((DescriptionAttribute) attributes[0]).Description : name;
            return result;
        }

        public static bool IsLanguageSpecific<TEnum>(this TEnum value) where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum)
            {
                throw new ArgumentException(string.Format("{0} must be an enumerated type", type));
            }
            var name = value.ToString();
            var attributes = type.GetField(name).GetCustomAttributes(typeof(LanguageSpecificAttribute), false);
            return attributes.Length > 0;
        }
    }
}