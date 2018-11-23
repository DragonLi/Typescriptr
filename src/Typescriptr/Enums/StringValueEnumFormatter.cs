using System;
using System.Text;

namespace Typescriptr.Enums
{
    public class StringValueEnumFormatter : IEnumFormatter
    {
        public string Start() {
            return string.Empty;
        }

        public string FormatType(Type enumType, QuoteStyle quoteStyle) {
            var builder = new StringBuilder();

            builder.AppendLine($"export enum {enumType.Name} {{");

            foreach (var enumName in enumType.GetEnumNames()) {
                var value = quoteStyle == QuoteStyle.Single ? $"'{enumName}'" : $"\"{enumName}\"";
                builder.AppendLine($"{TypeScriptGenerator.TabString}{enumName} = {value},");
            }

            builder.AppendLine("}");

            return builder.ToString();
        }

        public string FormatProperty(Type enumType, QuoteStyle quoteStyle) {
            return EnumPropertyFormatters.UnionStringEnumPropertyTypeFormatter(enumType, quoteStyle);
        }

        public string End() {
            return string.Empty;
        }
    }
}