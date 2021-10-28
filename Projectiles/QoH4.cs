using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class QoH4 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("QoH4");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(503);
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.aiStyle = 5;
			AIType = 503;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = 503;
			return true;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			damage *= 2;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.immune[Projectile.owner] = 1;
		}
	}
}
