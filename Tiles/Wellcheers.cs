using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace AlchemistNPC.Tiles
{
	public class Wellcheers : ModTile
	{
		public static int counter = 0;
		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.CoordinateHeights = new[]{16, 16, 16, 18};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Wellcheers");
			name.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Торговый автомат 'Wellcheers'");
            name.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "韦尔奇乐自动售货机");
            AddMapEntry(new Color(200, 200, 200), name);
			TileID.Sets.DisableSmartCursor[Type] = true;
			AdjTiles =new int[]{ TileID.Books };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameX < 66)
			{
				r = 0.9f;
				g = 0.9f;
				b = 0.9f;
			}
		}
		
		public override bool RightClick(int i, int j)
		{
			for (int k = 0; k < 255; k++)
			{
			Player player = Main.player[k];
			if (player.active)
				{
				if (counter != 10 && !Main.dayTime && !NPC.AnyNPCs(125) && !NPC.AnyNPCs(126) && !NPC.AnyNPCs(127) && !NPC.AnyNPCs(134))
					{
					switch (Main.rand.Next(4))
						{
							case 0:						
							player.QuickSpawnItem(ModContent.ItemType<Items.CrimsonCherrySoda>());
							counter++;
							break;
							case 1:
							player.QuickSpawnItem(ModContent.ItemType<Items.SapphireBlueberrySoda>());
							counter++;
							break;
							case 2:
							player.QuickSpawnItem(ModContent.ItemType<Items.PinkGoldStrawberrySoda>());
							counter++;
							break;
							case 3:
							player.QuickSpawnItem(ModContent.ItemType<Items.OnyxGrapeSoda>());
							counter++;
							break;
						}
					}
					if (counter == 10 && !Main.dayTime)
					{
						// IMPLEMENT WHEN WEAKREFERENCES FIXED
						/*
						Mod ALIB = ModLoader.GetMod("AchievementLib");
						if(ALIB != null)
						{
							ALIB.Call("UnlockGlobal", "AlchemistNPC", "The snack that smiles back");
						}
						*/
						if (Main.netMode == 0)
						{
							switch (Main.rand.Next(3))
							{
							case 0:
							NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronPrime);
							counter = 0;
							break;
							case 1:
							NPC.SpawnOnPlayer(player.whoAmI, NPCID.Retinazer);
							NPC.SpawnOnPlayer(player.whoAmI, NPCID.Spazmatism);
							counter = 0;
							break;
							case 2:
							NPC.SpawnOnPlayer(player.whoAmI, NPCID.TheDestroyer);
							counter = 0;
							break;
							}
						}
						if(Main.netMode != 0)
						{
						Main.player[Main.myPlayer].AddBuff(ModContent.BuffType<Buffs.EvilPresence>(), 1);
						counter = 0;
						}
					}
				}
			}
			return true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeable.Wellcheers>());
		}
		
		public override void MouseOver(int i, int j)
		{
			int whoAmI = 0;
			Player player = Main.player[whoAmI];
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Wellcheers>();
		}
	}
}