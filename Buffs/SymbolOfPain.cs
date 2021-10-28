using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class SymbolOfPain : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Symbol of Pain");
			Description.SetDefault("Weakens enemies");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Символ Боли");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ослабляет противников");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "痛苦法印");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "虚弱敌人");
        }
	}
}
