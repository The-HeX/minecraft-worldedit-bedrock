namespace WorldEdit
{
    public interface ICommandFormater
    {
        string Fill(int startX, int startY, int startz, int endX, int endY, int endZ, string block = "stone",
            string data = "0");

        string Title(string title, string subtitle);
    }
}