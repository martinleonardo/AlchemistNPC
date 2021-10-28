using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Twilight : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Pale");
			Description.SetDefault("Life's being drained out of you..");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бледный урон Сумерек");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Жизненные силы иссякают..");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "苍白的蕾蒂希娅");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "生命从你的身体中流失...");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<ModGlobalNPC>().twilight = true;
        }
	}
}
