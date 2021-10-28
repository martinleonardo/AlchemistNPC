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
	public class TwilightLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Leggings (O-02-63)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумеречные Поножи (O-02-63)"); 
			Tooltip.SetDefault("''Efforts of three birds to defeat the beast became one."
			+ "\nIt could stop countless incidents but you’d have to be prepared to step into the Black Forest.''"
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\n30% increased movement speed");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Усилия трёх птиц, чтобы одолеть Зверя, стали едиными.\nОно способно остановить бесчисленные несчастные случаи.\nНо вам нужно быть готовыми, чтобы войти в Тёмный Лес.''\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость передвижения на 30%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "薄暝袜统 (O-02-63)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'为了击退黑森林里的可怕“怪物”, 三只鸟齐心协力, 合为一体.'\n'它能避免很多无辜的人遇害, 但在那之前, 你必须做好万无一失的准备, 去踏入那片黑暗而又绝望的森林.'\n[c/FF0000:EGO 盔甲]\n增加30%移动速度");
        }

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = 11;
			Item.defense = 35;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.30f;
			player.AddBuff(ModContent.BuffType<Buffs.BigBirdLamp>(), 60);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "JustitiaLeggings")
				.AddIngredient(null, "BigBirdLamp")
				.AddIngredient(null, "EmagledFragmentation", 150)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}