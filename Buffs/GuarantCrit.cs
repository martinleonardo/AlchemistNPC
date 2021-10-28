using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class GuarantCrit : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Guaranteed Crit");
			Description.SetDefault("Your next attack would be critical");
			Main.persistentBuff[Type] = true;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Гарантированный Крит");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ваша следующая атаку будет гарантированным критом");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "暴击预定");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "下一次攻击必定暴击");

        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetCritChance(DamageClass.Melee) += 100;
			player.GetCritChance(DamageClass.Ranged) += 100;
			player.GetCritChance(DamageClass.Magic) += 100;
			player.GetCritChance(DamageClass.Throwing) += 100;
			player.AddBuff(ModContent.BuffType<Buffs.GuarantCrit>(), 2);
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).GC == false)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
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
				Calamity.Call("AddRogueCrit", player, 100);
			}
			*/
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetCritChance(DamageClass.Druid) += 100;
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetCritChance(DamageClass.Symphonic) += 100;
            Thoriumplayer.GetCritChance(DamageClass.Radiant) += 100;
        }
		*/
	}
}
