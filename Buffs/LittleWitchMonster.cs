using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Buffs
{
	public class LittleWitchMonster : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Little Witch Monster");
			Description.SetDefault("So that's what it contained...");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монстр Маленькой Ведьмы");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Так вот что было внутри...");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "小巫怪");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "嗯，这就是它里面的东西...");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.LittleWitchMonster>()] < 1)
			{
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X-15, player.position.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.Minions.LittleWitchMonster>(), 24, 3f, player.whoAmI);
				modPlayer.lwm = true;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}