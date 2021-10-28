using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class JustitiaPale : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia Pale");
			Description.SetDefault("Life's being drained out of you..");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бледность Юстиции");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Жизненные силы иссякают..");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "无力的审判鸟");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "生命从你的身体中流失...");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ModGlobalNPC>().justitiapale = true;
        }
	}
}
