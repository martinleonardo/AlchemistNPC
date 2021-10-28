using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Devilsknife : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devilsknife");
			Description.SetDefault("METAMORPHOSIS!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кинжал Дьявола");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "МЕТАМОРФОЗА!");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪匕");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蜕变!");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.Devilsknife>()] > 0)
			{
				modPlayer.devilsknife = true;
			}
			if (!modPlayer.devilsknife)
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