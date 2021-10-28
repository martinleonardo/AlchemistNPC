using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ReverberationLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reverberation Leggings (T-04-53)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Поножи Реверберации (T-04-53)"); 
			Tooltip.SetDefault("The sleek surface is tough as if it had been cured several times."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases movement speed by 25%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Гладкая поверхность тверда, как будто была усилена несколько раз.\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость передвижения на 25%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "余香裤子 (T-04-53)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'经过数次加工处理后, 这件护甲的表面变得光滑而又坚硬.'\n[c/FF0000:EGO 盔甲]\n增加25%移动速度");
        }

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 9;
			Item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 8)
				.AddIngredient(ItemID.DynastyWood, 80)
				.AddIngredient(ItemID.SoulofLight, 8)
				.AddIngredient(ItemID.SoulofNight, 8)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}