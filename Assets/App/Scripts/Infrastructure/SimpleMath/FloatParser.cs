namespace App.Scripts.Infrastructure.SimpleMath
{
    public static class FloatParser
    {
        public static bool TryParseFloat(string input, out float result)
        {
            result = 0f;

            if (input == null)
                return false;

            input = input.Trim();

            if (input.Length == 0)
                return false;

            bool negative = false;
            int i = 0;

            if (input[0] == '-')
            {
                negative = true;
                i = 1;
            }
            else if (input[0] == '+')
            {
                i = 1;
            }

            if (i >= input.Length)
                return false;

            long integerPart = 0;
            bool hasIntegerDigits = false;
            bool hasFractionDigits = false;
            bool hasSeparator = false;
            long fractionPart = 0;
            int fractionDigits = 0;

            for (; i < input.Length; i++)
            {
                char c = input[i];

                if (c >= '0' && c <= '9')
                {
                    if (hasSeparator)
                    {
                        fractionPart = fractionPart * 10 + (c - '0');
                        fractionDigits++;
                        hasFractionDigits = true;
                    }
                    else
                    {
                        integerPart = integerPart * 10 + (c - '0');
                        hasIntegerDigits = true;
                    }
                }
                else if ((c == '.' || c == ',') && !hasSeparator)
                {
                    hasSeparator = true;
                }
                else
                {
                    return false;
                }
            }

            if (!hasIntegerDigits && !hasFractionDigits)
                return false;

            double value = integerPart;

            if (fractionDigits > 0)
            {
                double divisor = 1;
                for (int d = 0; d < fractionDigits; d++)
                    divisor *= 10;
                value += fractionPart / divisor;
            }

            if (negative)
                value = -value;

            result = (float)value;
            return true;
        }
    }
}