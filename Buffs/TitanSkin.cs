using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TitanSkin : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titan Skin");
			Description.SetDefault("You are immune to some annoying debuffs");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кожа Титана");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Иммунитет к некоторым надоедливым дебаффам");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "泰坦皮肤");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "免疫一些烦人的Debuff");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			if (NPC.downedMechBoss2)
			{
			player.buffImmune[39] = true;
			player.buffImmune[69] = true;
			}
			player.buffImmune[24] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			
		}
	}
}
