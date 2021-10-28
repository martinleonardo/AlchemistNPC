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
	public class CrystalDust : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Dust");
			Tooltip.SetDefault("Dust made from Crystal Shards.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кристальная пыль");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пьль, сделанная из осколков кристалла");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "水晶粉尘");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "用碎魔晶捻成的粉尘");
        }    
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CrystalShard)
				.AddTile(TileID.Autohammer)
				.Register();
		}
	}
}
