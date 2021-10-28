using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CalamityComb : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calamity Combination");
			Description.SetDefault("Perfect sum of Calamity buffs"
			+"\nYharim's Stimulants, Cadence, Fabsol's Vodka, Soaring, Bounding and Titan Scale");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Каламити");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Идеальное сочетание баффов Каламити мода\nДает эффект Стимулянтов Ярима, Каденции, Водки Фабсола, Полёта, Связующего и Титановой Чешуи");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "灾厄药剂包");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "完美结合了以下灾厄药剂的Buff：\n魔君牌兴奋剂、尾音药剂、Fabsol伏特加、腾飞、跳跃、泰坦之鳞药剂");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("Cadence")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("YharimPower")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("TitanScale")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("FabsolVodkaBuff")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("Soaring")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("BoundingBuff")] = true;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player);
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				RedemptionBoost(player);
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				CalamityBoost(player, ref buffIndex);
			}
			*/
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		private void CalamityBoost(Player player, ref int buffIndex)
        {
			Calamity.GetBuff("Cadence").Update(player, ref buffIndex);
			Calamity.GetBuff("YharimPower").Update(player, ref buffIndex);
			Calamity.GetBuff("TitanScale").Update(player, ref buffIndex);
			Calamity.GetBuff("FabsolVodkaBuff").Update(player, ref buffIndex);
			Calamity.GetBuff("Soaring").Update(player, ref buffIndex);
			Calamity.GetBuff("BoundingBuff").Update(player, ref buffIndex);
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetCritChance(DamageClass.Druid) += 2;
        }
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetCritChance(DamageClass.Symphonic) += 2;
            Thoriumplayer.GetCritChance(DamageClass.Radiant) += 2;
        }
		*/
	}
}
