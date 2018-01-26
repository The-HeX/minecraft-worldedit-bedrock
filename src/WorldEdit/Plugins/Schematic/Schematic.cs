using System.Collections.Generic;
using System.Linq;
using fNbt;

namespace WorldEdit.Schematic
{
    public class Schematic
    {
        public short Height { get; set; }
        public short Width { get; set; }
        public short Length { get; set; }
        public byte[] Data { get; set; }
        public short[] Blocks { get; set; }

        public List<Point> GetPoints()
        {
            var jeBlocknames = BlockNameLoopup.BlockNames();
            var beBlocknames = BlockNameLoopup.BlockNamesBE();
            var blocknames = BlockNameLoopup.Lookup();
            var output = new List<Point>();

            for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
            for (var z = 0; z < Length; z++)
            {
                var index = x + (y * Length + z) * Width;
                var blockID = Blocks[index];//& 0xFF;
                var meta = Data[index] & 0xFF;
                var blockLookup =  BlockLookup(blocknames, beBlocknames, blockID);
                //var blockName = jeBlocknames.Length>blockID? jeBlocknames[blockID]:"stone";
                output.Add(new Point
                {
                    BlockName = blockLookup.Name,
                    BlockId = blockID,
                    Data = blockLookup.BeData>0? blockLookup.BeData:  meta,
                    X = x,
                    Y = y,
                    Z = z,
                    SortOrder=blockLookup.SortOrder
                });
            }

            return output;
        }

        private BlockLookup BlockLookup(List<BlockLookup> blocknames, string[] beBlocknames, short blockID)
        {
            return Materials.Equals("Pocket") ?  blocknames.Where(a => a.Name== beBlocknames[blockID]).DefaultIfEmpty(new BlockLookup() { Name = "air" }).FirstOrDefault():  blocknames.Where(a => a.Id == blockID).DefaultIfEmpty(new BlockLookup() {Name = "air"}).FirstOrDefault();
        }

        public static Schematic LoadFromFile(string FileName)
        {
            var output = new Schematic();
            var schematicFile = new NbtFile();

            schematicFile.LoadFromFile(FileName);
            output.Height = schematicFile.RootTag.Get<NbtShort>("Height").Value;
            output.Width = schematicFile.RootTag.Get<NbtShort>("Width").Value;
            output.Length = schematicFile.RootTag.Get<NbtShort>("Length").Value;
            output.BlockIds = schematicFile.RootTag.Get<NbtByteArray>("Blocks").Value;
            output.Data = schematicFile.RootTag.Get<NbtByteArray>("Data").Value;
            
            output.Materials = schematicFile.RootTag.Get<NbtString>("Materials").Value;

            var nbtByteArray = schematicFile.RootTag.Get<NbtByteArray>("AddBlocks");
            if (nbtByteArray != null)
            {
                output.AddBlock = nbtByteArray.Value;
            }
            else
            {
                output.AddBlock = new byte [0];
            }
            output.Blocks = new short[output.BlockIds.Length]; // Have to later combine IDs

            for (int index = 0; index < output.Blocks.Length; index++)
            {
                if ((index >> 1) >= output.AddBlock.Length)
                { 
                    output.Blocks[index] = (short)(output.BlockIds[index] & 0xFF);
                }
                else
                {
                    if ((index & 1) == 0)
                    {
                        output.Blocks[index] = (short)(((output.AddBlock[index >> 1] & 0x0F) << 8) + (output.BlockIds[index] & 0xFF));
                    }
                    else
                    {
                        output.Blocks[index] = (short)(((output.AddBlock[index >> 1] & 0xF0) << 4) + (output.BlockIds[index] & 0xFF));
                    }
                }
            }


            return output;
        }

        public string Materials { get; set; }

        public byte[] BlockIds { get; set; }

        public byte[] AddBlock { get; set; }
        //private static void WriteTag(NbtCompound rootTag)
        //{
        //    foreach (var tag in rootTag)
        //    {
        //        Console.WriteLine($"{tag.Name} {tag.TagType}");
        //        if (tag.TagType == NbtTagType.Compound)
        //            WriteTag((NbtCompound) tag);
        //        if (tag.TagType == NbtTagType.List)
        //            WriteTag((NbtList) tag);
        //    }
        //}

        //private static void WriteTag(NbtList rootTag)
        //{
        //    foreach (var tag in rootTag)
        //    {
        //        Console.WriteLine($"{tag.Name} {tag.TagType}");
        //        if (tag.TagType == NbtTagType.Compound)
        //            WriteTag((NbtCompound) tag);
        //        if (tag.TagType == NbtTagType.List)
        //            WriteTag((NbtList) tag);
        //    }
        //}
    }
}