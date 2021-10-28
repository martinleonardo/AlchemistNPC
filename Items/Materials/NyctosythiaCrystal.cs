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
	public class NyctosythiaCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyctosythia Crystal");
			Tooltip.SetDefault("Diamond of Nihility"
			+"\nConsumes any form of light");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кристалл Никтосифии");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Алмаз Нигилизма\nПоглощает любой вид света");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "夜蛾水晶");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "夜蛾的钻石\n消耗任意形式的光");
        }    
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 50000;
			Item.rare = 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Diamond)
				.AddIngredient(null, "CrystalDust", 3)
				.AddIngredient(ItemID.SoulofNight, 3)
				.AddIngredient(ItemID.FragmentVortex, 2)
				.AddIngredient(ItemID.FragmentStardust, 2)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
