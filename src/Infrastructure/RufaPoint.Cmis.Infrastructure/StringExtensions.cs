using RufaPoint.Cmis.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RufaPoint.Cmis.Infrastructure
{
    public static class StringExtensions
    {
        /// <summary>
		/// Converts a string either to a pascal or camel case string. http://www.biggle.de/blog/string-nach-pascal-und-camelcase-c-quicky
		/// </summary>
		/// <returns>The resulting string.</returns>
		/// <param name="value">The string to be converted.</param>
		/// <param name="stringCase">String case.</param>
		public static string ToCaseString(this string value, StringCase stringCase)
        {
            string[] splittedPhrase = value.Split(' ', '-', '.');
            var sb = new StringBuilder();

            if (stringCase == StringCase.CamelCase)
            {
                sb.Append(splittedPhrase[0].ToLower());
                splittedPhrase[0] = string.Empty;
            }
            else if (stringCase == StringCase.PascalCase)
                sb = new StringBuilder();

            foreach (String s in splittedPhrase)
            {
                char[] splittedPhraseChars = s.ToCharArray();
                if (splittedPhraseChars.Length > 0)
                {
                    splittedPhraseChars[0] = ((new String(splittedPhraseChars[0], 1)).ToUpper().ToCharArray())[0];
                }
                sb.Append(new String(splittedPhraseChars));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts the first character of each word to lower.
        /// </summary>
        /// <returns>The resukting string.</returns>
        /// <param name="value">The string to be converted.</param>
        public static string ToLowerFirstChar(this string value)
        {
            string[] splittedPhrase = value.Split(' ', '-', '.');
            var sb = new StringBuilder();

            foreach (String s in splittedPhrase)
            {
                sb.Append(Char.ToLowerInvariant(s[0]) + s.Substring(1));
            }

            return sb.ToString();
        }
    }
}
