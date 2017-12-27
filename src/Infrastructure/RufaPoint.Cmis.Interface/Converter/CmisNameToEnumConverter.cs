namespace RufaPoint.Cmis.Interface.Converter
{
    using RufaPoint.Cmis.Infrastructure;
    using System;
	using System.Reflection;

    /// <summary>
    /// CMIS name to enum converter. Converts CMIS compliant names to enum values, <see cref="T:CmisNameAttribute"/>.
    /// </summary>
    public static class CmisNameToEnumConverter
    {
        /// <summary>
        /// Converts a enum value to a CMIS name.
        /// </summary>
        /// <returns>The resulting CMIS name.</returns>
        /// <param name="value">The enum value to be converted.</param>
        public static string ToCmisName(this Enum value)
        {
            if (value == null)
                return null;

            var fieldInfo = value.GetType().GetRuntimeField(value.ToString());
            var attribute = fieldInfo.GetCustomAttribute(typeof(CmisNameAttribute), false) as CmisNameAttribute;
            if (attribute == null)
                return null;

            return attribute.Name;
        }

        /// <summary>
        /// Converts a CMIS name string to an enum value.
        /// </summary>
        /// <returns>The resulting enum value.</returns>
        /// <param name="value">The CMIS name stirng to be converted.</param>
        /// <typeparam name="T">The type of the enum to be returned.</typeparam>
        public static T ToEnum<T>(this string value)
        {
            var t = typeof(T);
            var underlyingType = Nullable.GetUnderlyingType(t);
            if (underlyingType != null)
            {
                t = underlyingType;
            }

			foreach (var fieldInfo in t.GetRuntimeFields())
			{
                if (fieldInfo.GetCustomAttribute(typeof(CmisNameAttribute), false) is CmisNameAttribute attribute && attribute.Name == value)
                {
                    return (T)Enum.Parse(t, fieldInfo.Name);
                }
            }

            return default(T);
        }
    }
}
