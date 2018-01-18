namespace WorldEdit
{
    public class WebsocketCommandFormater : ICommandFormater
    {
        public string Fill(int startX, int startY, int startz, int endX, int endY, int endZ, string block = "stone",
            string data = "0")
        {
            return $"fill {startX} {startY} {startz} {endX} {endY} {endZ} {block} {data}";
        }

        public string Title(string title, string subtitle)
        {
            var command = "title @s ";
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