using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class WatcherCrystal : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Watcher Crystal");
			Description.SetDefault("The powers of Galaxy support you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кристалл-наблюдатель");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Силы Галактики поддерживают вас");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "凝视者水晶");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "银河之力在你身边环绕");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.WatcherCrystal>()] > 0)
			{
				modPlayer.watchercrystal = true;
			}
			if (!modPlayer.watchercrystal)
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
