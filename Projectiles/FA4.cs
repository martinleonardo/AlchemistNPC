using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class FA4 : ModProjectile
	{
		public static int CloudType = 0;
		public static int CloudChosenType = 0;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask of the Alchemist (Water)");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(510);
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.aiStyle = 2;
		}
		
		public override void Kill(int timeLeft)
		{
			Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 107);
			Gore.NewGore(Projectile.Center, Projectile.oldVelocity * 0.2f, 704, 1f);
			Gore.NewGore(Projectile.Center, Projectile.oldVelocity * 0.2f, 705, 1f);
			if (Projectile.owner == Main.myPlayer)
			{
				int num2 = Main.rand.Next(10, 15);
				for (int index = 0; index < num2; ++index)
				{
					Vector2 vector2 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					vector2.Normalize();
					vector2 *= Main.rand.Next(10, 201) * 0.01f;
					Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vector2.X*4f, vector2.Y*4f, 253, Projectile.damage, 1f, Projectile.owner, 0.0f, Main.rand.Next(-45, 1));
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 1;
		}
	}
}
