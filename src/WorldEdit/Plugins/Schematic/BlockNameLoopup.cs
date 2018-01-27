using System.Collections.Generic;

namespace WorldEdit.Schematic
{
    public class BlockNameLoopup
    {
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
            blockName[34] = "piston_head";
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
            blockName[84] = "jukebox";
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
            blockName[95] = "stained_glass";
            blockName[96] = "trapdoor";
            blockName[97] = "monster_egg";
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
            blockName[125] = "double_wooden_slab";
            blockName[126] = "wooden_slab";
            blockName[127] = "cocoa";
            blockName[128] = "sandstone_stairs";
            blockName[129] = "emerald_ore";
            blockName[130] = "ender_chest";
            blockName[131] = "tripwire_hook";
            blockName[132] = "tripwire_hook";
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
            blockName[157] = "activator_rail";
            blockName[158] = "dropper";
            blockName[159] = "stained_hardened_clay";
            blockName[160] = "stained_glass_pane";
            blockName[161] = "leaves2";
            blockName[162] = "log2";
            blockName[163] = "acacia_stairs";
            blockName[164] = "dark_oak_stairs";
            blockName[165] = "slime";
            blockName[166] = "barrier";
            blockName[167] = "iron_trapdoor";
            blockName[168] = "prismarine";
            blockName[169] = "sea_lantern";
            blockName[170] = "hay_block";
            blockName[171] = "carpet";
            blockName[172] = "hardened_clay";
            blockName[173] = "coal_block";
            blockName[174] = "packed_ice";
            blockName[175] = "double_plant";
            blockName[176] = "standing_banner";
            blockName[177] = "wall_banner";
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
            blockName[188] = "spruce_fence";
            blockName[189] = "birch_fence";
            blockName[190] = "jungle_fence";
            blockName[191] = "dark_oak_fence";
            blockName[192] = "acacia_fence";
            blockName[193] = "spruce_door";
            blockName[194] = "birch_door";
            blockName[195] = "jungle_door";
            blockName[196] = "acacia_door";
            blockName[197] = "dark_oak_door";
            blockName[198] = "end_rod";
            blockName[199] = "chorus_plant";
            blockName[200] = "chorus_flower";
            blockName[201] = "purpur_block";
            blockName[202] = "purpur_pillar";
            blockName[203] = "purpur_stairs";
            blockName[204] = "purpur_double_slab";
            blockName[205] = "purpur_slab";
            blockName[206] = "end_bricks";
            blockName[207] = "beetroots";
            blockName[208] = "grass_path";
            blockName[209] = "end_gateway";
            blockName[210] = "repeating_command_block";
            blockName[211] = "chain_command_block";
            blockName[212] = "frosted_ice";
            blockName[213] = "magma";
            blockName[214] = "nether_wart_block";
            blockName[215] = "red_nether_brick";
            blockName[216] = "bone_block";
            blockName[217] = "structure_void";
            blockName[218] = "observer";
            blockName[219] = "white_shulker_box";
            blockName[220] = "orange_shulker_box";
            blockName[221] = "magenta_shulker_box";
            blockName[222] = "light_blue_shulker_box";
            blockName[223] = "yellow_shulker_box";
            blockName[224] = "lime_shulker_box";
            blockName[225] = "pink_shulker_box";
            blockName[226] = "gray_shulker_box";
            blockName[227] = "silver_shulker_box";
            blockName[228] = "cyan_shulker_box";
            blockName[229] = "purple_shulker_box";
            blockName[230] = "blue_shulker_box";
            blockName[231] = "brown_shulker_box";
            blockName[232] = "green_shulker_box";
            blockName[233] = "red_shulker_box";
            blockName[234] = "black_shulker_box";
            blockName[235] = "white_glazed_terracotta";
            blockName[236] = "orange_glazed_terracotta";
            blockName[237] = "magenta_glazed_terracotta";
            blockName[238] = "light_blue_glazed_terracotta";
            blockName[239] = "yellow_glazed_terracotta";
            blockName[240] = "lime_glazed_terracotta";
            blockName[241] = "pink_glazed_terracotta";
            blockName[242] = "gray_glazed_terracotta";
            blockName[243] = "light_gray_glazed_terracotta";
            blockName[244] = "cyan_glazed_terracotta";
            blockName[245] = "purple_glazed_terracotta";
            blockName[246] = "blue_glazed_terracotta";
            blockName[247] = "brown_glazed_terracotta";
            blockName[248] = "green_glazed_terracotta";
            blockName[249] = "red_glazed_terracotta";
            blockName[250] = "black_glazed_terracotta";
            blockName[251] = "concrete";
            blockName[252] = "concrete_powder";
            blockName[255] = "structure_block";

            return blockName;
        }

        public static string[] BlockNamesBE()
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
            blockName[97] = "monster_egg";
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

        public static List<BlockLookup> Lookup()
        {
            var output = new List<BlockLookup>();
            output.Add(new BlockLookup {Id = 0, Name = "air", BeData = 0, JeData = 0, FriendlyName = "Air"});
            output.Add(new BlockLookup {Id = 1, Name = "stone", BeData = 0, JeData = 0, FriendlyName = "Stone"});
            output.Add(new BlockLookup {Id = 1, Name = "stone", BeData = 1, JeData = 1, FriendlyName = "Granite"});
            output.Add(new BlockLookup
            {
                Id = 1,
                Name = "stone",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Polished Granite"
            });
            output.Add(new BlockLookup {Id = 1, Name = "stone", BeData = 3, JeData = 3, FriendlyName = "Diorite"});
            output.Add(new BlockLookup
            {
                Id = 1,
                Name = "stone",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Polished Diorite"
            });
            output.Add(new BlockLookup {Id = 1, Name = "stone", BeData = 5, JeData = 5, FriendlyName = "Andesite"});
            output.Add(new BlockLookup
            {
                Id = 1,
                Name = "stone",
                BeData = 6,
                JeData = 6,
                FriendlyName = "Polished Andesite"
            });
            output.Add(new BlockLookup {Id = 2, Name = "grass", BeData = 0, JeData = 0, FriendlyName = "Grass"});
            output.Add(new BlockLookup {Id = 3, Name = "dirt", BeData = 0, JeData = 0, FriendlyName = "Dirt"});
            output.Add(new BlockLookup {Id = 3, Name = "dirt", BeData = 1, JeData = 1, FriendlyName = "Coarse Dirt"});
            output.Add(new BlockLookup {Id = 3, Name = "dirt", BeData = 2, JeData = 2, FriendlyName = "Podzol"});
            output.Add(new BlockLookup
            {
                Id = 4,
                Name = "cobblestone",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Cobblestone"
            });
            output.Add(new BlockLookup
            {
                Id = 5,
                Name = "planks",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Oak Wood Plank"
            });
            output.Add(new BlockLookup
            {
                Id = 5,
                Name = "planks",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Spruce Wood Plank"
            });
            output.Add(new BlockLookup
            {
                Id = 5,
                Name = "planks",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Birch Wood Plank"
            });
            output.Add(new BlockLookup
            {
                Id = 5,
                Name = "planks",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Jungle Wood Plank"
            });
            output.Add(new BlockLookup
            {
                Id = 5,
                Name = "planks",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Acacia Wood Plank"
            });
            output.Add(new BlockLookup
            {
                Id = 5,
                Name = "planks",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Dark Oak Wood Plank"
            });
            output.Add(new BlockLookup {Id = 6, Name = "sapling", BeData = 0, JeData = 0, FriendlyName = "Oak Sapling"});
            output.Add(new BlockLookup
            {
                Id = 6,
                Name = "sapling",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Spruce Sapling"
            });
            output.Add(new BlockLookup
            {
                Id = 6,
                Name = "sapling",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Birch Sapling"
            });
            output.Add(new BlockLookup
            {
                Id = 6,
                Name = "sapling",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Jungle Sapling"
            });
            output.Add(new BlockLookup
            {
                Id = 6,
                Name = "sapling",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Acacia Sapling"
            });
            output.Add(new BlockLookup
            {
                Id = 6,
                Name = "sapling",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Dark Oak Sapling"
            });
            output.Add(new BlockLookup {Id = 7, Name = "bedrock", BeData = 0, JeData = 0, FriendlyName = "Bedrock"});
            output.Add(new BlockLookup
            {
                Id = 8,
                Name = "flowing_water",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Flowing Water",
                SortOrder = 10
            });
            output.Add(new BlockLookup
            {
                Id = 9,
                Name = "water",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Still Water",
                SortOrder = 10
            });
            output.Add(new BlockLookup
            {
                Id = 10,
                Name = "flowing_lava",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Flowing Lava",
                SortOrder = 11
            });
            output.Add(new BlockLookup
            {
                Id = 11,
                Name = "lava",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Still Lava",
                SortOrder = 11
            });
            output.Add(new BlockLookup
            {
                Id = 12,
                Name = "sand",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Sand",
                SortOrder = 2
            });
            output.Add(new BlockLookup
            {
                Id = 12,
                Name = "sand",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Red Sand",
                SortOrder = 2
            });
            output.Add(new BlockLookup
            {
                Id = 13,
                Name = "gravel",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Gravel",
                SortOrder = 2
            });
            output.Add(new BlockLookup {Id = 14, Name = "gold_ore", BeData = 0, JeData = 0, FriendlyName = "Gold Ore"});
            output.Add(new BlockLookup {Id = 15, Name = "iron_ore", BeData = 0, JeData = 0, FriendlyName = "Iron Ore"});
            output.Add(new BlockLookup {Id = 16, Name = "coal_ore", BeData = 0, JeData = 0, FriendlyName = "Coal Ore"});
            output.Add(new BlockLookup {Id = 17, Name = "log", BeData = 0, JeData = 0, FriendlyName = "Oak Wood"});
            output.Add(new BlockLookup {Id = 17, Name = "log", BeData = 1, JeData = 1, FriendlyName = "Spruce Wood"});
            output.Add(new BlockLookup {Id = 17, Name = "log", BeData = 2, JeData = 2, FriendlyName = "Birch Wood"});
            output.Add(new BlockLookup {Id = 17, Name = "log", BeData = 3, JeData = 3, FriendlyName = "Jungle Wood"});
            output.Add(new BlockLookup {Id = 18, Name = "leaves", BeData = 0, JeData = 0, FriendlyName = "Oak Leaves"});
            output.Add(new BlockLookup
            {
                Id = 18,
                Name = "leaves",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Spruce Leaves"
            });
            output.Add(new BlockLookup {Id = 18, Name = "leaves", BeData = 2, JeData = 2, FriendlyName = "Birch Leaves"});
            output.Add(new BlockLookup
            {
                Id = 18,
                Name = "leaves",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Jungle Leaves"
            });
            output.Add(new BlockLookup {Id = 19, Name = "sponge", BeData = 0, JeData = 0, FriendlyName = "Sponge"});
            output.Add(new BlockLookup {Id = 19, Name = "sponge", BeData = 1, JeData = 1, FriendlyName = "Wet Sponge"});
            output.Add(new BlockLookup {Id = 20, Name = "glass", BeData = 0, JeData = 0, FriendlyName = "Glass"});
            output.Add(new BlockLookup
            {
                Id = 21,
                Name = "lapis_ore",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Lapis Lazuli Ore"
            });
            output.Add(new BlockLookup
            {
                Id = 22,
                Name = "lapis_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Lapis Lazuli Block"
            });
            output.Add(new BlockLookup {Id = 23, Name = "dispenser", BeData = 0, JeData = 0, FriendlyName = "Dispenser"});
            output.Add(new BlockLookup {Id = 24, Name = "sandstone", BeData = 0, JeData = 0, FriendlyName = "Sandstone"});
            output.Add(new BlockLookup
            {
                Id = 24,
                Name = "sandstone",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Chiseled Sandstone"
            });
            output.Add(new BlockLookup
            {
                Id = 24,
                Name = "sandstone",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Smooth Sandstone"
            });
            output.Add(new BlockLookup
            {
                Id = 25,
                Name = "noteblock",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Note Block"
            });
            output.Add(new BlockLookup
            {
                Id = 26,
                Name = "bed",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Bed",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 27,
                Name = "golden_rail",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Powered Rail"
            });
            output.Add(new BlockLookup
            {
                Id = 28,
                Name = "detector_rail",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Detector Rail"
            });
            output.Add(new BlockLookup
            {
                Id = 29,
                Name = "sticky_piston",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Sticky Piston"
            });
            output.Add(new BlockLookup {Id = 30, Name = "web", BeData = 0, JeData = 0, FriendlyName = "Cobweb"});
            output.Add(new BlockLookup
            {
                Id = 31,
                Name = "tallgrass",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Dead Shrub"
            });
            output.Add(new BlockLookup {Id = 31, Name = "tallgrass", BeData = 1, JeData = 1, FriendlyName = "Grass"});
            output.Add(new BlockLookup {Id = 31, Name = "tallgrass", BeData = 2, JeData = 2, FriendlyName = "Fern"});
            output.Add(new BlockLookup {Id = 32, Name = "deadbush", BeData = 0, JeData = 0, FriendlyName = "Dead Bush"});
            output.Add(new BlockLookup {Id = 33, Name = "piston", BeData = 0, JeData = 0, FriendlyName = "Piston"});
            output.Add(new BlockLookup {Id = 34, Name = "piston", BeData = 0, JeData = 0, FriendlyName = "Piston Head"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 0, JeData = 0, FriendlyName = "White Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 1, JeData = 1, FriendlyName = "Orange Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 2, JeData = 2, FriendlyName = "Magenta Wool"});
            output.Add(new BlockLookup
            {
                Id = 35,
                Name = "wool",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Light Blue Wool"
            });
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 4, JeData = 4, FriendlyName = "Yellow Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 5, JeData = 5, FriendlyName = "Lime Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 6, JeData = 6, FriendlyName = "Pink Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 7, JeData = 7, FriendlyName = "Gray Wool"});
            output.Add(new BlockLookup
            {
                Id = 35,
                Name = "wool",
                BeData = 8,
                JeData = 8,
                FriendlyName = "Light Gray Wool"
            });
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 9, JeData = 9, FriendlyName = "Cyan Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 10, JeData = 10, FriendlyName = "Purple Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 11, JeData = 11, FriendlyName = "Blue Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 12, JeData = 12, FriendlyName = "Brown Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 13, JeData = 13, FriendlyName = "Green Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 14, JeData = 14, FriendlyName = "Red Wool"});
            output.Add(new BlockLookup {Id = 35, Name = "wool", BeData = 15, JeData = 15, FriendlyName = "Black Wool"});
            output.Add(new BlockLookup
            {
                Id = 37,
                Name = "yellow_flower",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Dandelion"
            });
            output.Add(new BlockLookup {Id = 38, Name = "red_flower", BeData = 0, JeData = 0, FriendlyName = "Poppy"});
            output.Add(new BlockLookup
            {
                Id = 38,
                Name = "red_flower",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Blue Orchid"
            });
            output.Add(new BlockLookup {Id = 38, Name = "red_flower", BeData = 2, JeData = 2, FriendlyName = "Allium"});
            output.Add(new BlockLookup
            {
                Id = 38,
                Name = "red_flower",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Azure Bluet"
            });
            output.Add(new BlockLookup
            {
                Id = 38,
                Name = "red_flower",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Red Tulip"
            });
            output.Add(new BlockLookup
            {
                Id = 38,
                Name = "red_flower",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Orange Tulip"
            });
            output.Add(new BlockLookup
            {
                Id = 38,
                Name = "red_flower",
                BeData = 6,
                JeData = 6,
                FriendlyName = "White Tulip"
            });
            output.Add(new BlockLookup
            {
                Id = 38,
                Name = "red_flower",
                BeData = 7,
                JeData = 7,
                FriendlyName = "Pink Tulip"
            });
            output.Add(new BlockLookup
            {
                Id = 38,
                Name = "red_flower",
                BeData = 8,
                JeData = 8,
                FriendlyName = "Oxeye Daisy"
            });
            output.Add(new BlockLookup
            {
                Id = 39,
                Name = "brown_mushroom",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Brown Mushroom"
            });
            output.Add(new BlockLookup
            {
                Id = 40,
                Name = "red_mushroom",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Red Mushroom"
            });
            output.Add(new BlockLookup
            {
                Id = 41,
                Name = "gold_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Gold Block"
            });
            output.Add(new BlockLookup
            {
                Id = 42,
                Name = "iron_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Iron Block"
            });
            output.Add(new BlockLookup
            {
                Id = 43,
                Name = "double_stone_slab",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Double Stone Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 43,
                Name = "double_stone_slab",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Double Sandstone Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 43,
                Name = "double_stone_slab",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Double Wooden Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 43,
                Name = "double_stone_slab",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Double Cobblestone Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 43,
                Name = "double_stone_slab",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Double Brick Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 43,
                Name = "double_stone_slab",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Double Stone Brick Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 43,
                Name = "double_stone_slab",
                BeData = 6,
                JeData = 6,
                FriendlyName = "Double Nether Brick Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 43,
                Name = "double_stone_slab",
                BeData = 7,
                JeData = 7,
                FriendlyName = "Double Quartz Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 44,
                Name = "stone_slab",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Stone Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 44,
                Name = "stone_slab",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Sandstone Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 44,
                Name = "stone_slab",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Wooden Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 44,
                Name = "stone_slab",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Cobblestone Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 44,
                Name = "stone_slab",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Brick Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 44,
                Name = "stone_slab",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Stone Brick Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 44,
                Name = "stone_slab",
                BeData = 6,
                JeData = 6,
                FriendlyName = "Nether Brick Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 44,
                Name = "stone_slab",
                BeData = 7,
                JeData = 7,
                FriendlyName = "Quartz Slab"
            });
            output.Add(new BlockLookup {Id = 45, Name = "brick_block", BeData = 0, JeData = 0, FriendlyName = "Bricks"});
            output.Add(new BlockLookup {Id = 46, Name = "tnt", BeData = 0, JeData = 0, FriendlyName = "TNT"});
            output.Add(new BlockLookup {Id = 47, Name = "bookshelf", BeData = 0, JeData = 0, FriendlyName = "Bookshelf"});
            output.Add(new BlockLookup
            {
                Id = 48,
                Name = "mossy_cobblestone",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Moss Stone"
            });
            output.Add(new BlockLookup {Id = 49, Name = "obsidian", BeData = 0, JeData = 0, FriendlyName = "Obsidian"});
            output.Add(new BlockLookup
            {
                Id = 50,
                Name = "torch",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Torch",
                HasDirection = true
            });
            output.Add(new BlockLookup {Id = 51, Name = "fire", BeData = 0, JeData = 0, FriendlyName = "Fire"});
            output.Add(new BlockLookup
            {
                Id = 52,
                Name = "mob_spawner",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Monster Spawner"
            });
            output.Add(new BlockLookup
            {
                Id = 53,
                Name = "oak_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Oak Wood Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup {Id = 54, Name = "chest", BeData = 0, JeData = 0, FriendlyName = "Chest"});
            output.Add(new BlockLookup
            {
                Id = 55,
                Name = "redstone_wire",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Wire"
            });
            output.Add(new BlockLookup
            {
                Id = 56,
                Name = "diamond_ore",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Diamond Ore"
            });
            output.Add(new BlockLookup
            {
                Id = 57,
                Name = "diamond_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Diamond Block"
            });
            output.Add(new BlockLookup
            {
                Id = 58,
                Name = "crafting_table",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Crafting Table"
            });
            output.Add(new BlockLookup {Id = 59, Name = "wheat", BeData = 0, JeData = 0, FriendlyName = "Wheat Crops"});
            output.Add(new BlockLookup {Id = 60, Name = "farmland", BeData = 0, JeData = 0, FriendlyName = "Farmland"});
            output.Add(new BlockLookup {Id = 61, Name = "furnace", BeData = 0, JeData = 0, FriendlyName = "Furnace"});
            output.Add(new BlockLookup
            {
                Id = 62,
                Name = "lit_furnace",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Burning Furnace"
            });
            output.Add(new BlockLookup
            {
                Id = 63,
                Name = "standing_sign",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Standing Sign Block",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 64,
                Name = "wooden_door",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Oak Door Block",
                SortOrder = 3
            });
            output.Add(new BlockLookup
            {
                Id = 65,
                Name = "ladder",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Ladder",
                SortOrder = 2
            });
            output.Add(new BlockLookup
            {
                Id = 66,
                Name = "rail",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Rail",
                SortOrder = 2
            });
            output.Add(new BlockLookup
            {
                Id = 67,
                Name = "stone_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Cobblestone Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 68,
                Name = "wall_sign",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Wall-mounted Sign Block",
                SortOrder = 2
            });
            output.Add(new BlockLookup {Id = 69, Name = "lever", BeData = 0, JeData = 0, FriendlyName = "Lever"});
            output.Add(new BlockLookup
            {
                Id = 70,
                Name = "stone_pressure_plate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Stone Pressure Plate"
            });
            output.Add(new BlockLookup
            {
                Id = 71,
                Name = "iron_door",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Iron Door Block",
                SortOrder = 2
            });
            output.Add(new BlockLookup
            {
                Id = 72,
                Name = "wooden_pressure_plate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Wooden Pressure Plate"
            });
            output.Add(new BlockLookup
            {
                Id = 73,
                Name = "redstone_ore",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Ore"
            });
            output.Add(new BlockLookup
            {
                Id = 74,
                Name = "lit_redstone_ore",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Glowing Redstone Ore"
            });
            output.Add(new BlockLookup
            {
                Id = 75,
                Name = "unlit_redstone_torch",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Torch (off)",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 76,
                Name = "redstone_torch",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Torch (on)",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 77,
                Name = "stone_button",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Stone Button"
            });
            output.Add(new BlockLookup
            {
                Id = 78,
                Name = "snow_layer",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Snow",
                SortOrder = 2
            });
            output.Add(new BlockLookup {Id = 79, Name = "ice", BeData = 0, JeData = 0, FriendlyName = "Ice"});
            output.Add(new BlockLookup
            {
                Id = 80,
                Name = "snow",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Snow Block",
                SortOrder = 2
            });
            output.Add(new BlockLookup {Id = 81, Name = "cactus", BeData = 0, JeData = 0, FriendlyName = "Cactus"});
            output.Add(new BlockLookup {Id = 82, Name = "clay", BeData = 0, JeData = 0, FriendlyName = "Clay"});
            output.Add(new BlockLookup {Id = 83, Name = "reeds", BeData = 0, JeData = 0, FriendlyName = "Sugar Canes"});
            output.Add(new BlockLookup {Id = 84, Name = "jukebox", BeData = 0, JeData = 0, FriendlyName = "Jukebox"});
            output.Add(new BlockLookup {Id = 85, Name = "fence", BeData = 0, JeData = 0, FriendlyName = "Oak Fence"});
            output.Add(new BlockLookup {Id = 86, Name = "pumpkin", BeData = 0, JeData = 0, FriendlyName = "Pumpkin"});
            output.Add(new BlockLookup
            {
                Id = 87,
                Name = "netherrack",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Netherrack"
            });
            output.Add(new BlockLookup {Id = 88, Name = "soul_sand", BeData = 0, JeData = 0, FriendlyName = "Soul Sand"});
            output.Add(new BlockLookup {Id = 89, Name = "glowstone", BeData = 0, JeData = 0, FriendlyName = "Glowstone"});
            output.Add(new BlockLookup
            {
                Id = 90,
                Name = "portal",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Nether Portal"
            });
            output.Add(new BlockLookup
            {
                Id = 91,
                Name = "lit_pumpkin",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Jack o'Lantern"
            });
            output.Add(new BlockLookup {Id = 92, Name = "cake", BeData = 0, JeData = 0, FriendlyName = "Cake Block"});
            output.Add(new BlockLookup
            {
                Id = 93,
                Name = "unpowered_repeater",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Repeater Block (off)"
            });
            output.Add(new BlockLookup
            {
                Id = 94,
                Name = "powered_repeater",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Repeater Block (on)"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 0,
                JeData = 0,
                FriendlyName = "White Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Orange Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Magenta Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Light Blue Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Yellow Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Lime Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 6,
                JeData = 6,
                FriendlyName = "Pink Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 7,
                JeData = 7,
                FriendlyName = "Gray Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 8,
                JeData = 8,
                FriendlyName = "Light Gray Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 9,
                JeData = 9,
                FriendlyName = "Cyan Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 10,
                JeData = 10,
                FriendlyName = "Purple Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 11,
                JeData = 11,
                FriendlyName = "Blue Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 12,
                JeData = 12,
                FriendlyName = "Brown Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 13,
                JeData = 13,
                FriendlyName = "Green Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 14,
                JeData = 14,
                FriendlyName = "Red Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 95,
                Name = "stained_glass",
                BeData = 15,
                JeData = 15,
                FriendlyName = "Black Stained Glass"
            });
            output.Add(new BlockLookup
            {
                Id = 96,
                Name = "trapdoor",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Wooden Trapdoor"
            });
            output.Add(new BlockLookup
            {
                Id = 97,
                Name = "monster_egg",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Stone Monster Egg"
            });
            output.Add(new BlockLookup
            {
                Id = 97,
                Name = "monster_egg",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Cobblestone Monster Egg"
            });
            output.Add(new BlockLookup
            {
                Id = 97,
                Name = "monster_egg",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Stone Brick Monster Egg"
            });
            output.Add(new BlockLookup
            {
                Id = 97,
                Name = "monster_egg",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Mossy Stone Brick Monster Egg"
            });
            output.Add(new BlockLookup
            {
                Id = 97,
                Name = "monster_egg",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Cracked Stone Brick Monster Egg"
            });
            output.Add(new BlockLookup
            {
                Id = 97,
                Name = "monster_egg",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Chiseled Stone Brick Monster Egg"
            });
            output.Add(new BlockLookup
            {
                Id = 98,
                Name = "stonebrick",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Stone Bricks"
            });
            output.Add(new BlockLookup
            {
                Id = 98,
                Name = "stonebrick",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Mossy Stone Bricks"
            });
            output.Add(new BlockLookup
            {
                Id = 98,
                Name = "stonebrick",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Cracked Stone Bricks"
            });
            output.Add(new BlockLookup
            {
                Id = 98,
                Name = "stonebrick",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Chiseled Stone Bricks"
            });
            output.Add(new BlockLookup
            {
                Id = 99,
                Name = "brown_mushroom_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Brown Mushroom Block"
            });
            output.Add(new BlockLookup
            {
                Id = 100,
                Name = "red_mushroom_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Red Mushroom Block"
            });
            output.Add(new BlockLookup
            {
                Id = 101,
                Name = "iron_bars",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Iron Bars"
            });
            output.Add(new BlockLookup
            {
                Id = 102,
                Name = "glass_pane",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 103,
                Name = "melon_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Melon Block"
            });
            output.Add(new BlockLookup
            {
                Id = 104,
                Name = "pumpkin_stem",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Pumpkin Stem"
            });
            output.Add(new BlockLookup
            {
                Id = 105,
                Name = "melon_stem",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Melon Stem"
            });
            output.Add(new BlockLookup {Id = 106, Name = "vine", BeData = 0, JeData = 0, FriendlyName = "Vines"});
            output.Add(new BlockLookup
            {
                Id = 107,
                Name = "fence_gate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Oak Fence Gate"
            });
            output.Add(new BlockLookup
            {
                Id = 108,
                Name = "brick_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Brick Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 109,
                Name = "stone_brick_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Stone Brick Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup {Id = 110, Name = "mycelium", BeData = 0, JeData = 0, FriendlyName = "Mycelium"});
            output.Add(new BlockLookup
            {
                Id = 111,
                Name = "waterlily",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Lily Pad",
                SortOrder = 11
            });
            output.Add(new BlockLookup
            {
                Id = 112,
                Name = "double_stone_slab",
                BeData = 7,
                JeData = 0,
                FriendlyName = "Nether Brick"
            });
            output.Add(new BlockLookup
            {
                Id = 113,
                Name = "nether_brick_fence",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Nether Brick Fence"
            });
            output.Add(new BlockLookup
            {
                Id = 114,
                Name = "nether_brick_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Nether Brick Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 115,
                Name = "nether_wart",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Nether Wart"
            });
            output.Add(new BlockLookup
            {
                Id = 116,
                Name = "enchanting_table",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Enchantment Table"
            });
            output.Add(new BlockLookup
            {
                Id = 117,
                Name = "brewing_stand",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Brewing Stand"
            });
            output.Add(new BlockLookup {Id = 118, Name = "cauldron", BeData = 0, JeData = 0, FriendlyName = "Cauldron"});
            output.Add(new BlockLookup
            {
                Id = 119,
                Name = "end_portal",
                BeData = 0,
                JeData = 0,
                FriendlyName = "End Portal"
            });
            output.Add(new BlockLookup
            {
                Id = 120,
                Name = "end_portal_frame",
                BeData = 0,
                JeData = 0,
                FriendlyName = "End Portal Frame"
            });
            output.Add(new BlockLookup
            {
                Id = 121,
                Name = "end_stone",
                BeData = 0,
                JeData = 0,
                FriendlyName = "End Stone"
            });
            output.Add(new BlockLookup
            {
                Id = 122,
                Name = "dragon_egg",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Dragon Egg"
            });
            output.Add(new BlockLookup
            {
                Id = 123,
                Name = "redstone_lamp",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Lamp (inactive)"
            });
            output.Add(new BlockLookup
            {
                Id = 124,
                Name = "lit_redstone_lamp",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Lamp (active)"
            });
            output.Add(new BlockLookup
            {
                Id = 125,
                Name = "double_wooden_slab",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Double Oak Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 125,
                Name = "double_wooden_slab",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Double Spruce Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 125,
                Name = "double_wooden_slab",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Double Birch Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 125,
                Name = "double_wooden_slab",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Double Jungle Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 125,
                Name = "double_wooden_slab",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Double Acacia Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 125,
                Name = "double_wooden_slab",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Double Dark Oak Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 126,
                Name = "wooden_slab",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Oak Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 126,
                Name = "wooden_slab",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Spruce Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 126,
                Name = "wooden_slab",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Birch Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 126,
                Name = "wooden_slab",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Jungle Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 126,
                Name = "wooden_slab",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Acacia Wood Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 126,
                Name = "wooden_slab",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Dark Oak Wood Slab"
            });
            output.Add(new BlockLookup {Id = 127, Name = "cocoa", BeData = 0, JeData = 0, FriendlyName = "Cocoa"});
            output.Add(new BlockLookup
            {
                Id = 128,
                Name = "sandstone_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Sandstone Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 129,
                Name = "emerald_ore",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Emerald Ore"
            });
            output.Add(new BlockLookup
            {
                Id = 130,
                Name = "ender_chest",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Ender Chest"
            });
            output.Add(new BlockLookup
            {
                Id = 131,
                Name = "tripwire_hook",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Tripwire Hook"
            });
            output.Add(new BlockLookup
            {
                Id = 132,
                Name = "tripwire_hook",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Tripwire"
            });
            output.Add(new BlockLookup
            {
                Id = 133,
                Name = "emerald_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Emerald Block"
            });
            output.Add(new BlockLookup
            {
                Id = 134,
                Name = "spruce_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Spruce Wood Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 135,
                Name = "birch_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Birch Wood Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 136,
                Name = "jungle_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Jungle Wood Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 137,
                Name = "command_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Command Block"
            });
            output.Add(new BlockLookup {Id = 138, Name = "beacon", BeData = 0, JeData = 0, FriendlyName = "Beacon"});
            output.Add(new BlockLookup
            {
                Id = 139,
                Name = "cobblestone_wall",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Cobblestone Wall"
            });
            output.Add(new BlockLookup
            {
                Id = 139,
                Name = "cobblestone_wall",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Mossy Cobblestone Wall"
            });
            output.Add(new BlockLookup
            {
                Id = 140,
                Name = "flower_pot",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Flower Pot"
            });
            output.Add(new BlockLookup {Id = 141, Name = "carrots", BeData = 0, JeData = 0, FriendlyName = "Carrots"});
            output.Add(new BlockLookup {Id = 142, Name = "potatoes", BeData = 0, JeData = 0, FriendlyName = "Potatoes"});
            output.Add(new BlockLookup
            {
                Id = 143,
                Name = "wooden_button",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Wooden Button"
            });
            output.Add(new BlockLookup {Id = 144, Name = "skull", BeData = 0, JeData = 0, FriendlyName = "Mob Head"});
            output.Add(new BlockLookup {Id = 145, Name = "anvil", BeData = 0, JeData = 0, FriendlyName = "Anvil"});
            output.Add(new BlockLookup
            {
                Id = 146,
                Name = "trapped_chest",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Trapped Chest"
            });
            output.Add(new BlockLookup
            {
                Id = 147,
                Name = "light_weighted_pressure_plate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Weighted Pressure Plate (light)"
            });
            output.Add(new BlockLookup
            {
                Id = 148,
                Name = "heavy_weighted_pressure_plate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Weighted Pressure Plate (heavy)"
            });
            output.Add(new BlockLookup
            {
                Id = 149,
                Name = "unpowered_comparator",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Comparator (inactive)"
            });
            output.Add(new BlockLookup
            {
                Id = 150,
                Name = "powered_comparator",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Comparator (active)"
            });
            output.Add(new BlockLookup
            {
                Id = 151,
                Name = "daylight_detector",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Daylight Sensor"
            });
            output.Add(new BlockLookup
            {
                Id = 152,
                Name = "redstone_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Redstone Block"
            });
            output.Add(new BlockLookup
            {
                Id = 153,
                Name = "quartz_ore",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Nether Quartz Ore"
            });
            output.Add(new BlockLookup {Id = 154, Name = "hopper", BeData = 0, JeData = 0, FriendlyName = "Hopper"});
            output.Add(new BlockLookup
            {
                Id = 155,
                Name = "quartz_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Quartz Block"
            });
            output.Add(new BlockLookup
            {
                Id = 155,
                Name = "quartz_block",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Chiseled Quartz Block"
            });
            output.Add(new BlockLookup
            {
                Id = 155,
                Name = "quartz_block",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Pillar Quartz Block"
            });
            output.Add(new BlockLookup
            {
                Id = 156,
                Name = "quartz_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Quartz Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 157,
                Name = "activator_rail",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Activator Rail"
            });
            output.Add(new BlockLookup {Id = 158, Name = "dropper", BeData = 0, JeData = 0, FriendlyName = "Dropper"});
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 0,
                JeData = 0,
                FriendlyName = "White Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Orange Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Magenta Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Light Blue Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Yellow Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Lime Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 6,
                JeData = 6,
                FriendlyName = "Pink Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 7,
                JeData = 7,
                FriendlyName = "Gray Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 8,
                JeData = 8,
                FriendlyName = "Light Gray Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 9,
                JeData = 9,
                FriendlyName = "Cyan Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 10,
                JeData = 10,
                FriendlyName = "Purple Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 11,
                JeData = 11,
                FriendlyName = "Blue Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 12,
                JeData = 12,
                FriendlyName = "Brown Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 13,
                JeData = 13,
                FriendlyName = "Green Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 14,
                JeData = 14,
                FriendlyName = "Red Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 159,
                Name = "stained_hardened_clay",
                BeData = 15,
                JeData = 15,
                FriendlyName = "Black Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 0,
                JeData = 0,
                FriendlyName = "White Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Orange Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Magenta Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Light Blue Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Yellow Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Lime Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 6,
                JeData = 6,
                FriendlyName = "Pink Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 7,
                JeData = 7,
                FriendlyName = "Gray Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 8,
                JeData = 8,
                FriendlyName = "Light Gray Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 9,
                JeData = 9,
                FriendlyName = "Cyan Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 10,
                JeData = 10,
                FriendlyName = "Purple Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 11,
                JeData = 11,
                FriendlyName = "Blue Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 12,
                JeData = 12,
                FriendlyName = "Brown Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 13,
                JeData = 13,
                FriendlyName = "Green Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 14,
                JeData = 14,
                FriendlyName = "Red Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 160,
                Name = "stained_glass_pane",
                BeData = 15,
                JeData = 15,
                FriendlyName = "Black Stained Glass Pane"
            });
            output.Add(new BlockLookup
            {
                Id = 161,
                Name = "leaves2",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Acacia Leaves"
            });
            output.Add(new BlockLookup
            {
                Id = 161,
                Name = "leaves2",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Dark Oak Leaves"
            });
            output.Add(new BlockLookup {Id = 162, Name = "log2", BeData = 0, JeData = 0, FriendlyName = "Acacia Wood"});
            output.Add(new BlockLookup {Id = 162, Name = "log2", BeData = 1, JeData = 1, FriendlyName = "Dark Oak Wood"});
            output.Add(new BlockLookup
            {
                Id = 163,
                Name = "acacia_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Acacia Wood Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 164,
                Name = "dark_oak_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Dark Oak Wood Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup {Id = 165, Name = "slime", BeData = 0, JeData = 0, FriendlyName = "Slime Block"});
            output.Add(new BlockLookup {Id = 166, Name = "air", BeData = 0, JeData = 0, FriendlyName = "Barrier"});
            output.Add(new BlockLookup
            {
                Id = 167,
                Name = "iron_trapdoor",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Iron Trapdoor"
            });
            output.Add(new BlockLookup
            {
                Id = 168,
                Name = "prismarine",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Prismarine"
            });
            output.Add(new BlockLookup
            {
                Id = 168,
                Name = "prismarine",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Prismarine Bricks"
            });
            output.Add(new BlockLookup
            {
                Id = 168,
                Name = "prismarine",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Dark Prismarine"
            });
            output.Add(new BlockLookup
            {
                Id = 169,
                Name = "seaLantern",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Sea Lantern"
            });
            output.Add(new BlockLookup {Id = 170, Name = "hay_block", BeData = 0, JeData = 0, FriendlyName = "Hay Bale"});
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 0,
                JeData = 0,
                FriendlyName = "White Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Orange Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Magenta Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Light Blue Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Yellow Carpet"
            });
            output.Add(new BlockLookup {Id = 171, Name = "carpet", BeData = 5, JeData = 5, FriendlyName = "Lime Carpet"});
            output.Add(new BlockLookup {Id = 171, Name = "carpet", BeData = 6, JeData = 6, FriendlyName = "Pink Carpet"});
            output.Add(new BlockLookup {Id = 171, Name = "carpet", BeData = 7, JeData = 7, FriendlyName = "Gray Carpet"});
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 8,
                JeData = 8,
                FriendlyName = "Light Gray Carpet"
            });
            output.Add(new BlockLookup {Id = 171, Name = "carpet", BeData = 9, JeData = 9, FriendlyName = "Cyan Carpet"});
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 10,
                JeData = 10,
                FriendlyName = "Purple Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 11,
                JeData = 11,
                FriendlyName = "Blue Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 12,
                JeData = 12,
                FriendlyName = "Brown Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 13,
                JeData = 13,
                FriendlyName = "Green Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 14,
                JeData = 14,
                FriendlyName = "Red Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 171,
                Name = "carpet",
                BeData = 15,
                JeData = 15,
                FriendlyName = "Black Carpet"
            });
            output.Add(new BlockLookup
            {
                Id = 172,
                Name = "hardened_clay",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Hardened Clay"
            });
            output.Add(new BlockLookup
            {
                Id = 173,
                Name = "coal_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Block of Coal"
            });
            output.Add(new BlockLookup
            {
                Id = 174,
                Name = "packed_ice",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Packed Ice"
            });
            output.Add(new BlockLookup
            {
                Id = 175,
                Name = "double_plant",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Sunflower"
            });
            output.Add(new BlockLookup {Id = 175, Name = "double_plant", BeData = 1, JeData = 1, FriendlyName = "Lilac"});
            output.Add(new BlockLookup
            {
                Id = 175,
                Name = "double_plant",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Double Tallgrass"
            });
            output.Add(new BlockLookup
            {
                Id = 175,
                Name = "double_plant",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Large Fern"
            });
            output.Add(new BlockLookup
            {
                Id = 175,
                Name = "double_plant",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Rose Bush"
            });
            output.Add(new BlockLookup {Id = 175, Name = "double_plant", BeData = 5, JeData = 5, FriendlyName = "Peony"});
            output.Add(new BlockLookup
            {
                Id = 176,
                Name = "standing_banner",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Free-standing Banner"
            });
            output.Add(new BlockLookup
            {
                Id = 177,
                Name = "wall_banner",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Wall-mounted Banner"
            });
            output.Add(new BlockLookup
            {
                Id = 178,
                Name = "daylight_detector_inverted",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Inverted Daylight Sensor"
            });
            output.Add(new BlockLookup
            {
                Id = 179,
                Name = "red_sandstone",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Red Sandstone"
            });
            output.Add(new BlockLookup
            {
                Id = 179,
                Name = "red_sandstone",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Chiseled Red Sandstone"
            });
            output.Add(new BlockLookup
            {
                Id = 179,
                Name = "red_sandstone",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Smooth Red Sandstone"
            });
            output.Add(new BlockLookup
            {
                Id = 180,
                Name = "red_sandstone_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Red Sandstone Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 181,
                Name = "double_stone_slab2",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Double Red Sandstone Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 182,
                Name = "stone_slab2",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Red Sandstone Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 183,
                Name = "spruce_fence_gate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Spruce Fence Gate"
            });
            output.Add(new BlockLookup
            {
                Id = 184,
                Name = "birch_fence_gate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Birch Fence Gate"
            });
            output.Add(new BlockLookup
            {
                Id = 185,
                Name = "jungle_fence_gate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Jungle Fence Gate"
            });
            output.Add(new BlockLookup
            {
                Id = 186,
                Name = "dark_oak_fence_gate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Dark Oak Fence Gate"
            });
            output.Add(new BlockLookup
            {
                Id = 187,
                Name = "acacia_fence_gate",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Acacia Fence Gate"
            });
            output.Add(new BlockLookup {Id = 188, Name = "fence", BeData = 1, JeData = 0, FriendlyName = "Spruce Fence"});
            output.Add(new BlockLookup {Id = 189, Name = "fence", BeData = 2, JeData = 0, FriendlyName = "Birch Fence"});
            output.Add(new BlockLookup {Id = 190, Name = "fence", BeData = 3, JeData = 0, FriendlyName = "Jungle Fence"});
            output.Add(new BlockLookup
            {
                Id = 191,
                Name = "fence",
                BeData = 5,
                JeData = 0,
                FriendlyName = "Dark Oak Fence"
            });
            output.Add(new BlockLookup {Id = 192, Name = "fence", BeData = 4, JeData = 0, FriendlyName = "Acacia Fence"});
            output.Add(new BlockLookup
            {
                Id = 193,
                Name = "spruce_door",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Spruce Door Block"
            });
            output.Add(new BlockLookup
            {
                Id = 194,
                Name = "birch_door",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Birch Door Block"
            });
            output.Add(new BlockLookup
            {
                Id = 195,
                Name = "jungle_door",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Jungle Door Block"
            });
            output.Add(new BlockLookup
            {
                Id = 196,
                Name = "acacia_door",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Acacia Door Block"
            });
            output.Add(new BlockLookup
            {
                Id = 197,
                Name = "dark_oak_door",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Dark Oak Door Block"
            });
            output.Add(new BlockLookup {Id = 198, Name = "end_rod", BeData = 0, JeData = 0, FriendlyName = "End Rod"});
            output.Add(new BlockLookup
            {
                Id = 199,
                Name = "chorus_plant",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Chorus Plant"
            });
            output.Add(new BlockLookup
            {
                Id = 200,
                Name = "chorus_flower",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Chorus Flower"
            });
            output.Add(new BlockLookup
            {
                Id = 201,
                Name = "purpur_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Purpur Block"
            });
            output.Add(new BlockLookup {Id = 202, Name = "air", BeData = 0, JeData = 0, FriendlyName = "Purpur Pillar"});
            output.Add(new BlockLookup
            {
                Id = 203,
                Name = "purpur_stairs",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Purpur Stairs",
                HasDirection = true
            });
            output.Add(new BlockLookup
            {
                Id = 204,
                Name = "double_stone_slab2",
                BeData = 1,
                JeData = 0,
                FriendlyName = "Purpur Double Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 205,
                Name = "stone_slab2",
                BeData = 1,
                JeData = 0,
                FriendlyName = "Purpur Slab"
            });
            output.Add(new BlockLookup
            {
                Id = 206,
                Name = "end_bricks",
                BeData = 0,
                JeData = 0,
                FriendlyName = "End Stone Bricks"
            });
            output.Add(new BlockLookup
            {
                Id = 207,
                Name = "beetroot",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Beetroot Block"
            });
            output.Add(new BlockLookup
            {
                Id = 208,
                Name = "grass_path",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Grass Path"
            });
            output.Add(new BlockLookup
            {
                Id = 209,
                Name = "end_gateway",
                BeData = 0,
                JeData = 0,
                FriendlyName = "End Gateway"
            });
            output.Add(new BlockLookup
            {
                Id = 210,
                Name = "repeating_command_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Repeating Command Block"
            });
            output.Add(new BlockLookup
            {
                Id = 211,
                Name = "chain_command_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Chain Command Block"
            });
            output.Add(new BlockLookup
            {
                Id = 212,
                Name = "frosted_ice",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Frosted Ice"
            });
            output.Add(new BlockLookup {Id = 213, Name = "air", BeData = 0, JeData = 0, FriendlyName = "Magma Block"});
            output.Add(new BlockLookup
            {
                Id = 214,
                Name = "nether_wart",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Nether Wart Block"
            });
            output.Add(new BlockLookup
            {
                Id = 215,
                Name = "air",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Red Nether Brick"
            });
            output.Add(new BlockLookup {Id = 216, Name = "air", BeData = 0, JeData = 0, FriendlyName = "Bone Block"});
            output.Add(new BlockLookup {Id = 217, Name = "air", BeData = 0, JeData = 0, FriendlyName = "Structure Void"});
            output.Add(new BlockLookup {Id = 218, Name = "observer", BeData = 0, JeData = 0, FriendlyName = "Observer"});
            output.Add(new BlockLookup
            {
                Id = 219,
                Name = "shulker_box",
                BeData = 0,
                JeData = 0,
                FriendlyName = "White Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 220,
                Name = "shulker_box",
                BeData = 1,
                JeData = 0,
                FriendlyName = "Orange Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 221,
                Name = "shulker_box",
                BeData = 2,
                JeData = 0,
                FriendlyName = "Magenta Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 222,
                Name = "shulker_box",
                BeData = 3,
                JeData = 0,
                FriendlyName = "Light Blue Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 223,
                Name = "shulker_box",
                BeData = 4,
                JeData = 0,
                FriendlyName = "Yellow Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 224,
                Name = "shulker_box",
                BeData = 5,
                JeData = 0,
                FriendlyName = "Lime Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 225,
                Name = "shulker_box",
                BeData = 6,
                JeData = 0,
                FriendlyName = "Pink Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 226,
                Name = "shulker_box",
                BeData = 7,
                JeData = 0,
                FriendlyName = "Gray Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 227,
                Name = "shulker_box",
                BeData = 8,
                JeData = 0,
                FriendlyName = "Light Gray Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 228,
                Name = "shulker_box",
                BeData = 9,
                JeData = 0,
                FriendlyName = "Cyan Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 229,
                Name = "shulker_box",
                BeData = 10,
                JeData = 0,
                FriendlyName = "Purple Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 230,
                Name = "shulker_box",
                BeData = 11,
                JeData = 0,
                FriendlyName = "Blue Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 231,
                Name = "shulker_box",
                BeData = 12,
                JeData = 0,
                FriendlyName = "Brown Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 232,
                Name = "shulker_box",
                BeData = 13,
                JeData = 0,
                FriendlyName = "Green Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 233,
                Name = "shulker_box",
                BeData = 14,
                JeData = 0,
                FriendlyName = "Red Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 234,
                Name = "shulker_box",
                BeData = 15,
                JeData = 0,
                FriendlyName = "Black Shulker Box"
            });
            output.Add(new BlockLookup
            {
                Id = 235,
                Name = "white_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "White Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 236,
                Name = "orange_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Orange Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 237,
                Name = "magenta_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Magenta Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 238,
                Name = "light_blue_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Light Blue Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 239,
                Name = "yellow_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Yellow Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 240,
                Name = "lime_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Lime Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 241,
                Name = "pink_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Pink Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 242,
                Name = "gray_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Gray Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 243,
                Name = "gray_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Light Gray Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 244,
                Name = "cyan_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Cyan Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 245,
                Name = "purple_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Purple Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 246,
                Name = "blue_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Blue Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 247,
                Name = "brown_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Brown Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 248,
                Name = "green_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Green Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 249,
                Name = "red_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Red Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 250,
                Name = "black_glazed_terracotta",
                BeData = 0,
                JeData = 0,
                FriendlyName = "Black Glazed Terracotta"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 0,
                JeData = 0,
                FriendlyName = "White Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Orange Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Magenta Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Light Blue Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Yellow Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Lime Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 6,
                JeData = 6,
                FriendlyName = "Pink Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 7,
                JeData = 7,
                FriendlyName = "Gray Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 8,
                JeData = 8,
                FriendlyName = "Light Gray Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 9,
                JeData = 9,
                FriendlyName = "Cyan Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 10,
                JeData = 10,
                FriendlyName = "Purple Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 11,
                JeData = 11,
                FriendlyName = "Blue Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 12,
                JeData = 12,
                FriendlyName = "Brown Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 13,
                JeData = 13,
                FriendlyName = "Green Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 14,
                JeData = 14,
                FriendlyName = "Red Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 251,
                Name = "concrete",
                BeData = 15,
                JeData = 15,
                FriendlyName = "Black Concrete"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 0,
                JeData = 0,
                FriendlyName = "White Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 1,
                JeData = 1,
                FriendlyName = "Orange Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 2,
                JeData = 2,
                FriendlyName = "Magenta Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 3,
                JeData = 3,
                FriendlyName = "Light Blue Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 4,
                JeData = 4,
                FriendlyName = "Yellow Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 5,
                JeData = 5,
                FriendlyName = "Lime Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 6,
                JeData = 6,
                FriendlyName = "Pink Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 7,
                JeData = 7,
                FriendlyName = "Gray Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 7,
                JeData = 8,
                FriendlyName = "Light Gray Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 9,
                JeData = 9,
                FriendlyName = "Cyan Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 10,
                JeData = 10,
                FriendlyName = "Purple Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 11,
                JeData = 11,
                FriendlyName = "Blue Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 12,
                JeData = 12,
                FriendlyName = "Brown Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 13,
                JeData = 13,
                FriendlyName = "Green Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 14,
                JeData = 14,
                FriendlyName = "Red Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 252,
                Name = "concrete_powder",
                BeData = 15,
                JeData = 15,
                FriendlyName = "Black Concrete Powder"
            });
            output.Add(new BlockLookup
            {
                Id = 255,
                Name = "structure_block",
                BeData = 0,
                JeData = 0,
                FriendlyName = "structure block"
            });
            return output;
        }
    }

    public class BlockLookup
    {
        public int SortOrder { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int BeData { get; set; }
        public int JeData { get; set; }
        public string FriendlyName { get; set; }
        public bool HasDirection { get; set; }
    }
}