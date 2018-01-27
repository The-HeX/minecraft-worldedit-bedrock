namespace WorldEdit
{
    public class CodeConnectCommandFormater : ICommandFormater
    {
        public string Fill(int startX, int startY, int startZ, int endX, int endY, int endZ, string block, string data)
        {
            return
                $"fill?from={startX} {startY} {startZ}&to={endX} {endY} {endZ}&tileName={block}&tileData={data}";
        }

        public string Title(string title, string subtitle)
        {
            var command = "executeasother?origin=@p&position=~%20~%20~&command=title%20@s%20";
            if (!string.IsNullOrEmpty(title))
            {
                command = command + "title " + title;
            }
            if (!string.IsNullOrEmpty(subtitle))
            {
                command = command + "subtitle " + subtitle;
            }
            return command;
        }
    }
}