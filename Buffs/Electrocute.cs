using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Buffs
{
	public class Electrocute : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electrocute");
			Description.SetDefault("High voltage is flowing through you");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Электрошок");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Через вас проходит высокое напряжение");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "触电");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "高压电流过你的身体..");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<ModGlobalNPC>().electrocute = true;
			if (Main.rand.Next(20) == 0 && npc.type != 488)
			{
			npc.velocity.X = 0.1f;
			npc.velocity.Y = 0.1f;
			}
        }
	}
}
