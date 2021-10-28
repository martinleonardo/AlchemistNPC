using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class BastScroll : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bast's Scroll");
			Description.SetDefault("Attacks obliterate enemy's armor");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			CanBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Свиток Баст");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Атаки полностью разрушают броню противника.");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巴斯特卷轴");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "攻击完全摧毁敌人护甲");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPC.BastScroll = true;
		}
	}
}
