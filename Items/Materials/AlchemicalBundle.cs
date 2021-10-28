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
	public class AlchemicalBundle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemical Bundle");
			Tooltip.SetDefault("Contains some Lunar Materials"
				+ "\nRequired for making Elixir of Life");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Алхимический набор");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Содержит в себе немного Лунных материалов\nНеобходим для создания Эликсира Жизни");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炼金捆绑包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "包含一些月之材料\n制作仙丹需要用到它");
        }    
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 2500000;
			Item.rare = 9;
			Item.knockBack = 6;
			Item.noMelee = true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.FragmentSolar, 25)
				.AddIngredient(ItemID.FragmentNebula, 25)
				.AddIngredient(ItemID.FragmentVortex, 25)
				.AddIngredient(ItemID.FragmentStardust, 25)
				.AddIngredient(ItemID.LunarOre, 50)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
