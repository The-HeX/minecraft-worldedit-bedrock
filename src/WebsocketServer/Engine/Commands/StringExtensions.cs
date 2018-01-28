namespace WorldEdit.Commands
{
    public static class StringExtensions
    {
        public static int ToInt(this string input)
        {
            return int.Parse(input);
        }
    }
}