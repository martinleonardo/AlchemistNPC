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
	public class SupremeEnergyCore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supreme Energy Core");
			Tooltip.SetDefault("Infinite source of Energy");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Превосходное энергетическое ядро");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бесконечный источник Энергии");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "至高能量核心");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "无限能量之源");
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
				.AddIngredient(null, "EnergyCell", 3996)
				.AddIngredient(ItemID.FragmentSolar, 10)
				.AddIngredient(ItemID.FragmentNebula, 10)
				.AddIngredient(ItemID.FragmentVortex, 10)
				.AddIngredient(ItemID.FragmentStardust, 10)
				.AddIngredient(null, "ChromaticCrystal")
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}
