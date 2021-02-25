namespace Spare.Extensions
{
    public static class StringExtensions
    {
        public static string PadCenter(this string str, int totalWidth)
        {
            var spaces = totalWidth - str.Length;
            var padLeft = spaces / 2 + str.Length;

            return str.PadLeft(padLeft).PadRight(totalWidth);
        }
    }
}
