﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using fNbt;
using ShapeGenerator;
using ShapeGenerator.Generators;

namespace ConsoleApplication2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int toX = 100, toY = 4, toZ = 100;
            var blocknames = BlockNames();
            string FileName = @"C:\Users\eric\Downloads\the-tavern.schematic";
            ConvertFileToCommands(toX, toY, toZ, blocknames, FileName, @"C:\Users\eric\Documents\GitHub\mcpe-geometry-generator\test.fill");
            Console.WriteLine("done");
            Console.ReadLine();
        }

        private static void ConvertFileToCommands(int toX, int toY, int toZ, string[] blocknames, string FileName,string outputFilename)
        {
            var schematicFile = new NbtFile();

            schematicFile.LoadFromFile(FileName);
            var h = schematicFile.RootTag.Get<NbtShort>("Height").Value;
            var w = schematicFile.RootTag.Get<NbtShort>("Width").Value;
            var l = schematicFile.RootTag.Get<NbtShort>("Length").Value;

            var blocks = schematicFile.RootTag.Get<NbtByteArray>("Blocks").Value;
            var data = schematicFile.RootTag.Get<NbtByteArray>("Data").Value;

            List<Point> points = CreatePoints(blocknames, h, w, l, blocks, data);

            var lines = SphereGenerator.LinesFromPoints(points);

            WriteLinesToCommandFile(toX, toY, toZ, outputFilename, lines);
        }

        private static void WriteLinesToCommandFile(int toX, int toY, int toZ, string outputFilename, List<Line> lines)
        {
            var file = File.CreateText(outputFilename);
            lines.Where(a => a.Block != 0).ToList().ForEach(a =>
            {
                file.WriteLine(a.Command(toX, toY, toZ));
            });
            file.Close();
        }

        private static List<Point> CreatePoints(string[] blocknames, short h, short w, short l, byte[] blocks, byte[] data)
        {
            var output = new List<Point>();
            foreach (var x1 in blocks.GroupBy(a => a & 0xFF).Select(a => new { BlockId = a.Key, Count = a.Count() })
                .OrderByDescending(a => a.Count))
                Console.WriteLine($"{x1.BlockId} {x1.Count}");

            for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                    for (var z = 0; z < l; z++)
                    {
                        var index = x + (y * l + z) * w;
                        var blockID = blocks[index] & 0xFF;
                        var meta = data[index] & 0xFF;
                        output.Add(new Point
                        {
                            BlockName = blocknames[blockID],
                            BlockId = blockID,
                            Data = meta,
                            X = x,
                            Y = y,
                            Z = z
                        });
                    }

            return output;
        }

        public static string[] BlockNames()
        {
            var blockName = new string[256];
            blockName[0] = "air";
            blockName[1] = "stone";
            blockName[2] = "grass";
            blockName[3] = "dirt";
            blockName[4] = "cobblestone";
            blockName[5] = "planks";
            blockName[6] = "sapling";
            blockName[7] = "bedrock";
            blockName[8] = "flowing_water";
            blockName[9] = "water";
            blockName[10] = "flowing_lava";
            blockName[11] = "lava";
            blockName[12] = "sand";
            blockName[13] = "gravel";
            blockName[14] = "gold_ore";
            blockName[15] = "iron_ore";
            blockName[16] = "coal_ore";
            blockName[17] = "log";
            blockName[18] = "leaves";
            blockName[19] = "sponge";
            blockName[20] = "glass";
            blockName[21] = "lapis_ore";
            blockName[22] = "lapis_block";
            blockName[23] = "dispenser";
            blockName[24] = "sandstone";
            blockName[25] = "noteblock";
            blockName[26] = "bed";
            blockName[27] = "golden_rail";
            blockName[28] = "detector_rail";
            blockName[29] = "sticky_piston";
            blockName[30] = "web";
            blockName[31] = "tallgrass";
            blockName[32] = "deadbush";
            blockName[33] = "piston";
            blockName[34] = "pistonArmCollision";
            blockName[35] = "wool";
            blockName[37] = "yellow_flower";
            blockName[38] = "red_flower";
            blockName[39] = "brown_mushroom";
            blockName[40] = "red_mushroom";
            blockName[41] = "gold_block";
            blockName[42] = "iron_block";
            blockName[43] = "double_stone_slab";
            blockName[44] = "stone_slab";
            blockName[45] = "brick_block";
            blockName[46] = "tnt";
            blockName[47] = "bookshelf";
            blockName[48] = "mossy_cobblestone";
            blockName[49] = "obsidian";
            blockName[50] = "torch";
            blockName[51] = "fire";
            blockName[52] = "mob_spawner";
            blockName[53] = "oak_stairs";
            blockName[54] = "chest";
            blockName[55] = "redstone_wire";
            blockName[56] = "diamond_ore";
            blockName[57] = "diamond_block";
            blockName[58] = "crafting_table";
            blockName[59] = "wheat";
            blockName[60] = "farmland";
            blockName[61] = "furnace";
            blockName[62] = "lit_furnace";
            blockName[63] = "standing_sign";
            blockName[64] = "wooden_door";
            blockName[65] = "ladder";
            blockName[66] = "rail";
            blockName[67] = "stone_stairs";
            blockName[68] = "wall_sign";
            blockName[69] = "lever";
            blockName[70] = "stone_pressure_plate";
            blockName[71] = "iron_door";
            blockName[72] = "wooden_pressure_plate";
            blockName[73] = "redstone_ore";
            blockName[74] = "lit_redstone_ore";
            blockName[75] = "unlit_redstone_torch";
            blockName[76] = "redstone_torch";
            blockName[77] = "stone_button";
            blockName[78] = "snow_layer";
            blockName[79] = "ice";
            blockName[80] = "snow";
            blockName[81] = "cactus";
            blockName[82] = "clay";
            blockName[83] = "reeds";
            blockName[85] = "fence";
            blockName[86] = "pumpkin";
            blockName[87] = "netherrack";
            blockName[88] = "soul_sand";
            blockName[89] = "glowstone";
            blockName[90] = "portal";
            blockName[91] = "lit_pumpkin";
            blockName[92] = "cake";
            blockName[93] = "unpowered_repeater";
            blockName[94] = "powered_repeater";
            blockName[95] = "invisibleBedrock";
            blockName[96] = "trapdoor";
            blockName[97] = "";
            blockName[98] = "stonebrick";
            blockName[99] = "brown_mushroom_block";
            blockName[100] = "red_mushroom_block";
            blockName[101] = "iron_bars";
            blockName[102] = "glass_pane";
            blockName[103] = "melon_block";
            blockName[104] = "pumpkin_stem";
            blockName[105] = "melon_stem";
            blockName[106] = "vine";
            blockName[107] = "fence_gate";
            blockName[108] = "brick_stairs";
            blockName[109] = "stone_brick_stairs";
            blockName[110] = "mycelium";
            blockName[111] = "waterlily";
            blockName[112] = "nether_brick";
            blockName[113] = "nether_brick_fence";
            blockName[114] = "nether_brick_stairs";
            blockName[115] = "nether_wart";
            blockName[116] = "enchanting_table";
            blockName[117] = "brewing_stand";
            blockName[118] = "cauldron";
            blockName[119] = "end_portal";
            blockName[120] = "end_portal_frame";
            blockName[121] = "end_stone";
            blockName[122] = "dragon_egg";
            blockName[123] = "redstone_lamp";
            blockName[124] = "lit_redstone_lamp";
            blockName[125] = "dropper";
            blockName[126] = "activator_rail";
            blockName[127] = "cocoa";
            blockName[128] = "sandstone_stairs";
            blockName[129] = "emerald_ore";
            blockName[130] = "ender_chest";
            blockName[131] = "tripwire_hook";
            blockName[132] = "tripWire";
            blockName[133] = "emerald_block";
            blockName[134] = "spruce_stairs";
            blockName[135] = "birch_stairs";
            blockName[136] = "jungle_stairs";
            blockName[137] = "command_block";
            blockName[138] = "beacon";
            blockName[139] = "cobblestone_wall";
            blockName[140] = "flower_pot";
            blockName[141] = "carrots";
            blockName[142] = "potatoes";
            blockName[143] = "wooden_button";
            blockName[144] = "skull";
            blockName[145] = "anvil";
            blockName[146] = "trapped_chest";
            blockName[147] = "light_weighted_pressure_plate";
            blockName[148] = "heavy_weighted_pressure_plate";
            blockName[149] = "unpowered_comparator";
            blockName[150] = "powered_comparator";
            blockName[151] = "daylight_detector";
            blockName[152] = "redstone_block";
            blockName[153] = "quartz_ore";
            blockName[154] = "hopper";
            blockName[155] = "quartz_block";
            blockName[156] = "quartz_stairs";
            blockName[157] = "double_wooden_slab";
            blockName[158] = "wooden_slab";
            blockName[159] = "stained_hardened_clay";
            blockName[160] = "stained_glass_pane";
            blockName[161] = "leaves2";
            blockName[162] = "log2";
            blockName[163] = "acacia_stairs";
            blockName[164] = "dark_oak_stairs";
            blockName[165] = "slime";
            blockName[167] = "iron_trapdoor";
            blockName[168] = "prismarine";
            blockName[169] = "seaLantern";
            blockName[170] = "hay_block";
            blockName[171] = "carpet";
            blockName[172] = "hardened_clay";
            blockName[173] = "coal_block";
            blockName[174] = "packed_ice";
            blockName[175] = "double_plant";
            blockName[178] = "daylight_detector_inverted";
            blockName[179] = "red_sandstone";
            blockName[180] = "red_sandstone_stairs";
            blockName[181] = "double_stone_slab2";
            blockName[182] = "stone_slab2";
            blockName[183] = "spruce_fence_gate";
            blockName[184] = "birch_fence_gate";
            blockName[185] = "jungle_fence_gate";
            blockName[186] = "dark_oak_fence_gate";
            blockName[187] = "acacia_fence_gate";
            blockName[188] = "repeating_command_block";
            blockName[189] = "chain_command_block";
            blockName[193] = "spruce_door";
            blockName[194] = "birch_door";
            blockName[195] = "jungle_door";
            blockName[196] = "acacia_door";
            blockName[197] = "dark_oak_door";
            blockName[198] = "grass_path";
            blockName[199] = "frame";
            blockName[200] = "chorus_flower";
            blockName[201] = "purpur_block";
            blockName[203] = "purpur_stairs";
            blockName[206] = "end_bricks";
            blockName[207] = "frosted_ice";
            blockName[208] = "end_rod";
            blockName[209] = "end_gateway";
            blockName[218] = "shulker_box";
            blockName[219] = "purple_glazed_terracotta";
            blockName[220] = "white_glazed_terracotta";
            blockName[221] = "orange_glazed_terracotta";
            blockName[222] = "magenta_glazed_terracotta";
            blockName[223] = "light_blue_glazed_terracotta";
            blockName[224] = "yellow_glazed_terracotta";
            blockName[225] = "lime_glazed_terracotta";
            blockName[226] = "pink_glazed_terracotta";
            blockName[227] = "gray_glazed_terracotta";
            blockName[228] = "silver_glazed_terracotta";
            blockName[229] = "cyan_glazed_terracotta";
            blockName[231] = "blue_glazed_terracotta";
            blockName[232] = "brown_glazed_terracotta";
            blockName[233] = "green_glazed_terracotta";
            blockName[234] = "red_glazed_terracotta";
            blockName[235] = "black_glazed_terracotta";
            blockName[236] = "concrete";
            blockName[237] = "concretePowder";
            blockName[240] = "chorus_plant";
            blockName[241] = "stained_glass";
            blockName[243] = "podzol";
            blockName[244] = "beetroot";
            blockName[245] = "stonecutter";
            blockName[246] = "glowingobsidian";
            blockName[247] = "netherreactor";
            blockName[248] = "info_update";
            blockName[249] = "info_update2";
            blockName[250] = "movingBlock";
            blockName[251] = "observer";
            blockName[255] = "reserved6";

            return blockName;
        }


        private static void WriteTag(NbtCompound rootTag)
        {
            foreach (var tag in rootTag)
            {
                Console.WriteLine($"{tag.Name} {tag.TagType}");
                if (tag.TagType == NbtTagType.Compound)
                    WriteTag((NbtCompound) tag);
                if (tag.TagType == NbtTagType.List)
                    WriteTag((NbtList) tag);
            }
        }

        private static void WriteTag(NbtList rootTag)
        {
            foreach (var tag in rootTag)
            {
                Console.WriteLine($"{tag.Name} {tag.TagType}");
                if (tag.TagType == NbtTagType.Compound)
                    WriteTag((NbtCompound) tag);
                if (tag.TagType == NbtTagType.List)
                    WriteTag((NbtList) tag);
            }
        }
    }

    //public class Position
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public int Z { get; set; }
    //    public int BlockId { get; set; }
    //    public int Data { get; set; }

    //    public string BlockName { get; set; }

    //    public string Command(int toX, int toY, int toZ)
    //    {
    //        return $"fill {toX + X} {toY + Y} {toZ + Z} {toX + X} {toY + Y} {toZ + Z} {BlockName} {Data}";
    //    }
    //}
}