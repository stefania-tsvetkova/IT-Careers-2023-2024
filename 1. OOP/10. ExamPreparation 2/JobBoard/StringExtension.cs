public static class StringExtension
{
    public static bool IsLengthInRange(this string str, int minValue, int maxValue)
    {
        return str.Length >= minValue && str.Length <= maxValue;
    }
}
