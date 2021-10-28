using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TwilightBoost : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Boost");
			Description.SetDefault("You are immune to damage and deal 3x damage");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумеречное Усиление");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы неуязвимы и наносите трёхкратный урон");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蕾蒂希娅增强");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "免疫伤害, 造成3倍伤害");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			if (player.HeldItem.type != ModContent.ItemType<Items.Twilight>())
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			player.immune = true;
			player.GetDamage(DamageClass.Thrown) += 3f;
			player.GetDamage(DamageClass.Melee) += 3f;
			player.GetDamage(DamageClass.Ranged) += 3f;
			player.GetDamage(DamageClass.Magic) += 3f;
			player.GetDamage(DamageClass.Minion) += 3f;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player);
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				RedemptionBoost(player);
			}
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				Calamity.Call("AddRogueDamage", player, 300);
			}
			*/
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
			Redemptionplayer.GetDamage(DamageClass.Druid) += 3f;
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetDamage(DamageClass.Symphonic) += 3f;
			ThoriumPlayer.radiantBoost += 3f;
        }
		*/
	}
}
