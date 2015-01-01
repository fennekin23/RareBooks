using System;

namespace Rb.Common
{
    [AttributeUsage(AttributeTargets.Field)]
    public class LanguageSpecificAttribute : Attribute
    {
        public LanguageSpecificAttribute(object noLangMember)
        {
            NoLangMember = noLangMember;
        }

        public object NoLangMember { get; private set; }
    }
}