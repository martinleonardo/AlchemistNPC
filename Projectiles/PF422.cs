using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class PF422 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PF422");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(190);
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.aiStyle = 39;
			AIType = 190;
		}
		
		public override void AI()
		{
			Projectile.velocity *= 1.2f;
			Projectile.velocity *= 1.02f;
			if (Projectile.rotation >= 10f)
			{
				Projectile.rotation = 1f;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.immune[Projectile.owner] = 2;
		Projectile.rotation++;
		}
	}
}
