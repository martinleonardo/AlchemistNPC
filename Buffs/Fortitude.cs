using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Fortitude : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fortitude");
			Description.SetDefault("You cannot be knocked back");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Стойкость");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Получение урона не отбрасывает вас");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "刚毅");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你无法被击退");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.noKnockback = true;
		}
	}
}
