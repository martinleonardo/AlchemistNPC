using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class ExplosionDummyQD : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ExplosionDummyQD");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.penetrate = 40;
			Projectile.timeLeft = 30;
			Projectile.tileCollide = false;
			AIType = ProjectileID.LaserMachinegunLaser;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
		}
	
	}
}
