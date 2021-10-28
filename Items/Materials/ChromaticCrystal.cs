using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Materials
{
	public class ChromaticCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chromatic Crystal");
			Tooltip.SetDefault("Hallowed Crystal, overflowed by power");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хроматический кристалл");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Святой кристалл, переполненный мощью");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炫彩水晶");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神圣的水晶, 充斥着无尽的能量");
        }    
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 5000;
			Item.rare = 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CrystalShard, 5)
				.AddIngredient(null, "CrystalDust", 3)
				.AddIngredient(ItemID.SoulofLight)
				.AddIngredient(ItemID.FragmentSolar)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
