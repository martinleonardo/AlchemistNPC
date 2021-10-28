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
	public class SunkroveraCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunkrovera Crystal");
			Tooltip.SetDefault("Ruby, containing Blood of Demons"
			+"\nIt burns you even through gloves");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кристалл Сункроверы");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Рубин, хранящий Кровь Демонов\nОбжигает вас даже сквозь перчатки");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "森克罗维拉水晶");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "内含恶魔之血的红宝石\n即使带着手套也会烧伤你");
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
				.AddIngredient(ItemID.Ruby)
				.AddIngredient(ItemID.LivingFireBlock, 3)
				.AddIngredient(null, "CrystalDust", 3)
				.AddIngredient(ItemID.SoulofFright, 3)
				.AddIngredient(ItemID.FragmentSolar, 2)
				.AddIngredient(ItemID.FragmentNebula, 2)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
