using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class ArmorDestruction : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Armor Destruction");
			Description.SetDefault("Total armor destruction");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			LongerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Разрушение брони");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Полное разрушение брони");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "盔甲破损");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你的盔甲爆了");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.ichor = true;
			npc.defense -= 99999;
			npc.defense = 0;
        }
	}
}
