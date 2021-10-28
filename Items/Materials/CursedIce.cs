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
	public class CursedIce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Ice");
			Tooltip.SetDefault("Cursed Flame, encapsulated in ice.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(3, 8));
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Проклятый лёд");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Проклятое Пламя, заключённое в лёд");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "诅咒之冰");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "诅咒之焰, 跃于冰内");
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
				.AddIngredient(ItemID.IceBlock, 5)
				.AddIngredient(ItemID.CursedFlame)
				.AddTile(TileID.CrystalBall)
				.Register();
		}
	}
}
