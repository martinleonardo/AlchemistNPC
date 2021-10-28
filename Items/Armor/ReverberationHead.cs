using System.Collections.Generic;
using System.Linq;
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
	public class ReverberationHead : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Reverberation Wreath (T-04-53)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Венок Реверберации (T-04-53)");
            Tooltip.SetDefault("The sleek surface is tough as if it had been cured several times."
            + "\n[c/FF0000:EGO armor piece]"
            + "\nIncreases ranged damage by 20%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Гладкая поверхность тверда, как будто была усилена несколько раз.\n[c/FF0000:Часть брони Э.П.О.С.]\nПовышает урон в дальнем бою на 20%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "余香花环 (T-04-53)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'经过数次加工处理后, 这件护甲的表面变得光滑而又坚硬.'\n[c/FF0000:EGO 盔甲]\n增加20%远程伤害");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "ReverberationSetBonus");
            text.SetDefault("Forms shield around weilder. Shield reduces all incoming damage by 15%\nSpeeds up all arrows\nImproves ''Reverberation'' repeater:\nLowers manacost for additional projectiles\nMakes repeater shoot multiple projectiles\nBoosts Druidic type damage and critical strike chance by 20%");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Создаёт щит вокруг владельца. Щит уменьшает весь входящий урон на 15%\nУскоряет все стрелы\nУлучшает арбалет 'Реверберация'\nУменьшает затраты маны на выстрел дополнительными снарядами\nАрбалет будет выстреливать несколько дополнительных снарядов\nУведичивает Друидский тип урона и шанс критического удара на 20%");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "在玩家周围形成一圈护盾. 护盾减少15%全部即将到来的伤害\n加速全部箭矢\n加强余香弩:\n降低额外子弹的魔法消耗\n让弩发射更多的子弹");
            LocalizationLoader.AddTranslation(text);
        }

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 9;
			Item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Ranged) += 0.2f;
		}
		
		//Fix when implemented
		/*
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		*/
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.ReverberationBody>() && legs.type == ModContent.ItemType<Items.Armor.ReverberationLegs>();
		}

		public override void UpdateArmorSet(Player player)
		{
			string ReverberationSetBonus = Language.GetTextValue("Mods.AlchemistNPC.ReverberationSetBonus");
			player.setBonus = ReverberationSetBonus;
			player.magicQuiver = true;
			player.AddBuff(ModContent.BuffType<Buffs.ShieldofSpring>(), 300);
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).RevSet = true;
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			if (ModLoader.GetMod("Redemption") != null)
			{
				RedemptionBoost(player);
			}
			*/
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
			RedemptionPlayer.druidDamage += 0.2f;
            Redemptionplayer.GetCritChance(DamageClass.Druid) += 20;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 10)
				.AddIngredient(ItemID.DynastyWood, 100)
				.AddIngredient(ItemID.SoulofLight, 10)
				.AddIngredient(ItemID.SoulofNight, 10)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}