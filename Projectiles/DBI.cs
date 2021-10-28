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
	public class DBI : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DBI");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.DamageType = DamageClass.Magic;
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 300;
			AIType = ProjectileID.Bullet;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Buffs.Twilight>(), 240);
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
		}
	
	}
}