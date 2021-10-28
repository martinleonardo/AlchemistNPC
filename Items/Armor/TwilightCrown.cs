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
	[AutoloadEquip(EquipType.Head)]
	public class TwilightCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Crown (O-02-63)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумеречная Корона (O-02-63)"); 
			Tooltip.SetDefault("''Efforts of three birds to defeat the beast became one."
			+ "\nIt could stop countless incidents but you’d have to be prepared to step into the Black Forest.''"
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases melee speed by 30%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "薄暝王冠 (O-02-63)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'为了击退黑森林里的可怕“怪物”, 三只鸟齐心协力, 合为一体.'\n'它能避免很多无辜的人遇害, 但在那之前, 你必须做好万无一失的准备, 去踏入那片黑暗而又绝望的森林.'\n[c/FF0000:EGO 盔甲]\n增加30%近战伤害");

            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Усилия трёх птиц, чтобы одолеть Зверя, стали едиными.\nОно способно остановить бесчисленные несчастные случаи.\nНо вам нужно быть готовыми, чтобы войти в Тёмный Лес.''\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость ближнего боя на 30%");
		    ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "TwilightSetBonus");
		    text.SetDefault("Increases current melee/magic damage by 30% and adds 15% to melee/magic critical strike chance"
		    + "\nIncludes all bonuses from Big Bird Lamp");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает текущий урон в ближнем бою/магический на 30% и добаляет 15% к шансу критического удара\nВключает в себя бонусы от Лампы Большой Птицы");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加30%当前近战/魔法伤害, 并增加15%近战/魔法暴击率\n包含大鸟灯的全部效果");
            LocalizationLoader.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = 11;
			Item.defense = 30;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.30f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.TwilightSuit>() && legs.type == ModContent.ItemType<Items.Armor.TwilightLeggings>();
		}
		
		//Fix when implemented
		/*
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}
		*/

		public override void UpdateArmorSet(Player player)
		{
			string TwilightSetBonus = Language.GetTextValue("Mods.AlchemistNPC.TwilightSetBonus");
			player.setBonus = TwilightSetBonus;
			player.GetDamage(DamageClass.Melee) += 0.35f;
			player.GetDamage(DamageClass.Magic) += 0.35f;
			player.GetCritChance(DamageClass.Melee) += 20;
			player.GetCritChance(DamageClass.Magic) += 20;
			player.AddBuff(ModContent.BuffType<Buffs.BigBirdLamp>(), 300);
			player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetDamage(DamageClass.Summon) += 0.05f;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "JustitiaCrown")
				.AddIngredient(null, "MasksBundle")
				.AddIngredient(null, "EmagledFragmentation", 100)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}