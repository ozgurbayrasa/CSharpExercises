using System.Numerics;

namespace NumberTypeSuggester
{
    internal class NumericTypeSuggester
    {
        public const string BigInteger = "BigInteger";
        public const string ULong = "ulong";
        public const string UInt = "uint";
        public const string UShort = "ushort";
        public const string Byte = "byte";
        public const string Long = "long";
        public const string Int = "int";
        public const string Short = "short";
        public const string SByte = "sbyte";
        public const string Decimal = "decimal";
        public const string Double = "double";
        public const string Float = "float";
        public const string ImpossibleRepresentation = "impossible representation";
        internal static string GetName(BigInteger minValue, BigInteger maxValue, 
            bool integerOnly, bool mustBePrecise)
        {
            return integerOnly ? GetIntegralNumberName(minValue, maxValue) : GetFloatingPointNumberName(minValue, maxValue, mustBePrecise);
        }

        private static string GetFloatingPointNumberName(BigInteger minValue, BigInteger maxValue, bool mustBePrecise)
        {
            if (mustBePrecise)
            {
                return GetPreciseFloatingPointNumbers(minValue, maxValue);
            }
            return GetImpreciseFloatingPointNumbers(minValue, maxValue);
        }

        private static string GetImpreciseFloatingPointNumbers(BigInteger minValue, BigInteger maxValue)
        {
            if (minValue >= new BigInteger(float.MinValue) &&
               maxValue <= new BigInteger(float.MaxValue))
            {
                return Float;
            }
            if (minValue >= new BigInteger(double.MinValue) &&
               maxValue <= new BigInteger(double.MaxValue))
            {
                return Double;
            }
            return ImpossibleRepresentation;
        }

        private static string GetPreciseFloatingPointNumbers(BigInteger minValue, BigInteger maxValue)
        {
            if (minValue >= new BigInteger(decimal.MinValue) &&
               maxValue <= new BigInteger(decimal.MaxValue))
            {
                return Decimal;
            }
            return ImpossibleRepresentation;
        }

        private static string GetIntegralNumberName(BigInteger minValue, BigInteger maxValue)
        {
            return minValue >= 0 ? GetUnsignedIntegralNumberName(maxValue) : GetSignedIntegralNumberName(minValue, maxValue);
        }

        private static string GetSignedIntegralNumberName(BigInteger minValue, BigInteger maxValue)
        {
            if(minValue > sbyte.MaxValue && maxValue < sbyte.MaxValue)
            {
                return SByte;
            }
            if (minValue > short.MaxValue && maxValue < short.MaxValue)
            {
                return Short;
            }
            if (minValue > int.MaxValue && maxValue < int.MaxValue)
            {
                return Int;
            }
            if (minValue > long.MaxValue && maxValue < long.MaxValue)
            {
                return Long;
            }
            return BigInteger;
        }

        private static string GetUnsignedIntegralNumberName(BigInteger maxValue)
        {
            if(maxValue < byte.MaxValue)
            {
                return Byte;
            }
            if (maxValue < ushort.MaxValue)
            {
                return UShort;
            }
            if (maxValue < uint.MaxValue)
            {
                return UInt;
            }
            if (maxValue < ulong.MaxValue)
            {
                return ULong;
            }
            return BigInteger;
        }
    }
}