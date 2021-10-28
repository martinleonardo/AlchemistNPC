using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.GameContent;

namespace AlchemistNPC.Projectiles
{
	public class LaserCannon : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laser Cannon");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bullet);
			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.timeLeft = 300;
			AIType = ProjectileID.Bullet;
		}
		
		public override void AI()
		{
			for (int i = 0; i < 2; i++)
				{
					int dustIndex = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<Dusts.RainbowDust>());
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.1f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.1f;
					dust.scale *= 0.9f;
					dust.noGravity = true;
				}
			
			if (Projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref Projectile.velocity);
				Projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 300f;
			bool target = false;
			for (int k = 0; k < 100; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - Projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				Projectile.velocity = (10 * Projectile.velocity + move) / 5f;
				AdjustMagnitude(ref Projectile.velocity);
			}
		}
		
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 9f / magnitude;
			}
		}
		
		public override bool PreDraw(ref Color lightColor) {
            
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int i = 0; i < Projectile.oldPos.Length; i++) {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(TextureAssets.Projectile[Projectile.type].Value, drawPos, new Rectangle(0, Projectile.frame * TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type], TextureAssets.Projectile[Projectile.type].Value.Width, TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type]), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }
		
		public override bool PreKill(int timeLeft)
		{
			Terraria.Audio.SoundEngine.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 62);
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vel.X, vel.Y, ModContent.ProjectileType<Projectiles.ExplosionPlasma>(), Projectile.damage, 0, Main.myPlayer);
			Projectile.type = ProjectileID.Bullet;
			return true;
		}
	}
}
