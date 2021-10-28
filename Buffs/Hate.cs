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
	public class Hate : ModBuff
	{
		public static int count = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hate");
			Description.SetDefault("You are ready to unleash your Hate");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ненависть");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы готовы выпустить свою Ненависть");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "仇恨");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "准备好释放你的仇恨吧!");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.statLife < player.statLifeMax2)
			{
				if (count >= 12)
				{
					count = 0;
					player.statLife += 5;
					player.HealEffect(5, true);
				}
				count++;
			}
			player.GetDamage(DamageClass.Generic) += 0.15f;
			player.GetCritChance(DamageClass.Melee) += 15;
			player.GetCritChance(DamageClass.Ranged) += 15;
			player.GetCritChance(DamageClass.Magic) += 15;
			player.GetCritChance(DamageClass.Throwing) += 15;
			player.lifeRegen += 20;
			player.endurance -= 0.15f;
			player.statDefense -= 30;
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
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
				Calamity.Call("AddRogueCrit", player, 15);
			}
			*/
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetCritChance(DamageClass.Druid) += 15;
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetCritChance(DamageClass.Symphonic) += 15;
            Thoriumplayer.GetCritChance(DamageClass.Radiant) += 15;
        }
		*/
	}
}
