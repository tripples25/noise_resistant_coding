namespace noise_resistant_coding;

public static class IntExtensions
{
    public static string ToBin(this int number)
    {
        return Convert.ToString(number, 2);
    }
}
