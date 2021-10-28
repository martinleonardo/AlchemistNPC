using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Banned : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Banned");
			Description.SetDefault("was banned");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Забанен");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "был забанен");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "禁制");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "受到禁制");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ModGlobalNPC>().banned = true;
        }
	}
}
