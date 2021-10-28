using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class UgandanWarrior : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ugandan Warrior");
			Description.SetDefault("FO DE QWEEN!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Воин Уганды");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "ЗА КОРОЛЕВУ!");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "乌干达战士");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "为了女王!");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.UgandanWarrior>()] > 0)
			{
				modPlayer.uw = true;
			}
			if (!modPlayer.uw)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}