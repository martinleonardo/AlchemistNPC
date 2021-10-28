using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Slowness : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slowness");
			Description.SetDefault("Enemy is slowed down");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Замедление");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Противник замедлен");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "缓慢");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "减缓敌人");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.velocity *= 0.98f;
        }
	}
}
