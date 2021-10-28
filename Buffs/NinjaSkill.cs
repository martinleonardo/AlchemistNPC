using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class NinjaSkill : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ninja");
			Description.SetDefault("You are a true ninja!");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ниндзя");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы - истинный ниндзя!");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "忍者");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "现在你是个真正的忍者了!");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Generic) += 0.05f;
			player.GetCritChance(DamageClass.Melee) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
			player.blackBelt = true;
            player.spikedBoots = 2;
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
				Calamity.Call("AddRogueCrit", player, 5);
			}
			*/
		}
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetCritChance(DamageClass.Druid) += 5;
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetCritChance(DamageClass.Symphonic) += 5;
            Thoriumplayer.GetCritChance(DamageClass.Radiant) += 5;
        }
		*/
	}
}
