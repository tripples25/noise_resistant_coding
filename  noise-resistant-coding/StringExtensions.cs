namespace noise_resistant_coding;

public static class StringExtensions
{
    public static int ToDec(this string bin)
    {
        return Convert.ToInt32(bin, 2);
    }
}
