using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class DeadlyLaser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deadly Lazer");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(100);
			Projectile.width = 6;
			Projectile.tileCollide = false;
			Projectile.aiStyle = 1;
			Projectile.timeLeft = 600;
			AIType = 100;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.friendly)
			{
			damage = 5;
			}
		}
	}
}
