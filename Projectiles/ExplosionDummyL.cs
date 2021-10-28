using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class ExplosionDummyL : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosion Dummy");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.LaserMachinegunLaser);
			Projectile.DamageType = DamageClass.Magic;
			Projectile.width = 96;
			Projectile.height = 96;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 1;
			Projectile.tileCollide = false;
			AIType = ProjectileID.LaserMachinegunLaser;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
		}
	}
}
