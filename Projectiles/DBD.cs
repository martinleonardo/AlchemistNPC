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
	public class DBD : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("DBD");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);			Projectile.DamageType = DamageClass.Melee;
			Projectile.width = 60;
			Projectile.height = 34;
			Projectile.timeLeft = 300;
			AIType = ProjectileID.Bullet;
		}
		
		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.HellfireArrow;
			return true;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.lifeMax > 6666)
			{
			damage = 150;
			}
			if (target.lifeMax <= 6666)
			{
			damage = 6666;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			AlchemistNPC.DTH++;
		}
	}
}