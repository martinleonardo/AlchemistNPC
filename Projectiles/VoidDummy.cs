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
	public class VoidDummy : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.DamageType = DamageClass.Magic;
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 3;
			Projectile.timeLeft = 120;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Projectile Dummy");

		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.type == ModContent.NPCType<NPCs.BillCipher>())
			{
			damage /= 250;
			}
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 90)
			{
				Projectile.timeLeft = 90;
			}
			else
			{
				Projectile.ai[0] += 1f;
			}
			Projectile.rotation += 0.3f * Projectile.direction;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
		}
	}
}
