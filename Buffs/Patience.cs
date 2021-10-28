using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Patience : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Patience Paralyzation");
			Description.SetDefault("Freezes target in place");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Парализация Терпения");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Обездвиживает цель");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "耐力瘫痪");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "冻结目标");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			if (npc.type != 488)
			{
			npc.velocity.X = 0.1f;
			npc.velocity.Y = 0.1f;
			}
        }
	}
}
