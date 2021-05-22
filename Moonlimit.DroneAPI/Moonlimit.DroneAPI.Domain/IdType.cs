using System;
using System.ComponentModel;
using System.Globalization;

namespace Moonlimit.DroneAPI.Domain
{
    [TypeConverter(typeof(Base32IdTypeConverter))]
    public record IdType
    {
        public Int64 Value;
        public string Lexical;

        public IdType(Int64 value)
        {
            Value = value;
            Lexical = Base32Convert.ToString(value);
        }
        
        public IdType(string lexical)
        {
            Value = Base32Convert.ToInt64(lexical);
            Lexical = Base32Convert.ToString(Value);
        }

        public override string ToString() => Lexical;
        
        public static implicit operator Int64(IdType id) => id.Value;
        
        public static implicit operator IdType(Int64 id) => new IdType(id);
        
        public static implicit operator string(IdType id) => id.Lexical;

        public static explicit operator IdType(string value) => new IdType(value);
    }
    
    class Base32IdTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            => sourceType == typeof(string) || sourceType == typeof(Int64) || base.CanConvertFrom(context, sourceType);
        
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            object result = value switch
            {
                Int64 v => new IdType(v),
                string {Length: > 11 and < 14} v => new IdType(v),
                _ => base.ConvertFrom(context, culture, value)
            };
            return result;
        }
    }
}