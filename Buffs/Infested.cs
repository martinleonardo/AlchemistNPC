using Microsoft.Xna.Framework;
using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
    public class Infested : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infested");
            Description.SetDefault("Slowed, spiders are ready to burst");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            LongerExpertDebuff = true;
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Заражён");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Замедлен, пауки готовы к выходу");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蛛群滋生");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "减速，蜘蛛种群暴涨");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (!npc.boss)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (npc.type != 222 && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerGoliath")) && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlaguebringerShade")) && npc.type != (ModLoader.GetMod("CalamityMod").NPCType("PlagueBeeLargeG")))
					{	
						npc.velocity *= 0.95f;
					}
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					if (npc.type != 222)
					{	
						npc.velocity *= 0.95f;
					}
				}
				*/
                // DELETE WHEN IMPLEMENTED
                if (npc.type != 222)
                {
                    npc.velocity *= 0.95f;
                }
            }
        }
    }
}
