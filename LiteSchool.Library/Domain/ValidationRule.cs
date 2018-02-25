using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace LiteSchool.Library.Domain
{
    [DataContract()]
    [Serializable()]
    public class ValidationRule
    {
        [DataMember()]
        public string PropertyName;

        [DataMember()]
        public string Rule;

        [DataMember()]
        public Regex RegularExpression;

        public ValidationRule()
        {         
        }

        public ValidationRule(string propertyName, string rule)
        {
            PropertyName = propertyName;
            Rule = rule;
        }

        public ValidationRule(string propertyName, string rule, Regex regex)
        {
            PropertyName = propertyName;
            Rule = rule;
            RegularExpression = regex;
        }
    }

    public static class ValidationRuleExtension
    {
        public static string ToString(this List<ValidationRule> list, string separator)
        {
            StringBuilder text = new StringBuilder();
            if (list != null)
            {
                foreach (ValidationRule rule in list)
                {
                    text.Append(rule.Rule);
                    text.Append(separator);
                }

                return text.ToString();
            }
            else
                return string.Empty;
        }
    }
}
