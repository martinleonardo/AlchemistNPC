using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class RainbowFlaskBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Imbue");
			Description.SetDefault("You enemies will feel your strikes");
			Main.persistentBuff[Type] = true;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Радужное зачарование");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ваши враги почуствуют ваши удары");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "彩虹侵染");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你的敌人将受到你的迎头痛击");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().rainbowdust = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ModGlobalNPC>().rainbowdust = true;
		}
	}
}
