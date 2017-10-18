using System;
using System.Collections.Generic;
using System.Linq;
using fNbt;
using ShapeGenerator;

namespace SchematicExporter
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
            var output = new List<Point>();
            //foreach (var x1 in Blocks.GroupBy(a => a & 0xFF).Select(a => new {BlockId = a.Key, Count = a.Count()})
            //    .OrderByDescending(a => a.Count))
            //    Console.WriteLine($"{x1.BlockId} {x1.Count}");

            for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
            for (var z = 0; z < Length; z++)
            {
                var index = x + (y * Length + z) * Width;
                var blockID = Blocks[index];//& 0xFF;
                var meta = Data[index] & 0xFF;
                var blockName = jeBlocknames.Length>blockID? jeBlocknames[blockID]:"stone";
                if (!beBlocknames.Any(a => a == blockName))
                {
                    Console.WriteLine($"could not map {blockName}");
                }
                output.Add(new Point
                {
                    BlockName = blockName,
                    BlockId = blockID,
                    Data = meta,
                    X = x,
                    Y = y,
                    Z = z
                });
            }

            return output;
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