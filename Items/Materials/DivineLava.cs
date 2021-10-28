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
	public class DivineLava : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Lava");
			Tooltip.SetDefault("Ichor & Lava, combined together by magic");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вечная Лава");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лава и Ихор, слитые воедино магией");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "奇异岩浆");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "用法力把灵液和岩浆相结合");
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
				.AddIngredient(ItemID.Ichor)
				.AddIngredient(ItemID.LavaBucket)
				.AddTile(TileID.CrystalBall)
				.Register();
			CreateRecipe()
				.AddIngredient(ItemID.Ichor)
				.AddTile(TileID.CrystalBall)
				.AddCondition(Recipe.Condition.NearLava)
				.Register();
		}
	}
}
